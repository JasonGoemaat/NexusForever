using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NexusForever.GameTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace NexusForever.WorldServer.Api
{
    /// <summary>
    /// Handle generic table queries:
    ///     /tables - returns list of table names
    ///     /tables/{tableName} - returns list of entries (can use limit,offset, and field fielters)
    ///     /tables/{tableName}/{id} - returns a single entry
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TablesController : ControllerBase
    {
        private readonly ILogger<TablesController> _logger;

        public TablesController(ILogger<TablesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Return all table names from GameTableManager
        /// </summary>
        /// <returns>String array of all table names</returns>
        [HttpGet]
        public IEnumerable<string> GetTableNames()
        {
            Type t = typeof(GameTableManager);
            var properties = t.GetProperties();
            List<string> validTables = new List<string>();
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                if (property.GetValue(GameTableManager.Instance) == null)
                {
                    continue;
                }
                if (!property.PropertyType.IsGenericType)
                {
                    continue;
                }
                if (property.PropertyType.GetGenericTypeDefinition() != typeof(GameTable<>))
                {
                    continue;
                }
                validTables.Add(property.Name);
            }
            return validTables;
        }

        /// <summary>
        /// Return multiple results for a table as a map of ids to strings.  By default
        /// will return all entries, but can use limit and offset in query string to
        /// filter results.
        /// </summary>
        /// <param name="tableName">Name of the table that is a property of GameTableManager</param>
        /// <returns>Mapping of ids to strings</returns>
        [HttpGet("{tableName}")]
        public IActionResult GetTable(string tableName)
        {
            try
            {
                // get property of GameTableManager for the given table
                var property = typeof(GameTableManager).GetProperty(tableName);
                var tableValue = property.GetValue(GameTableManager.Instance);
                if (tableValue == null)
                {
                    return null;
                }

                // use reflection to get information from the table
                var tableType = tableValue.GetType();
                var getEntryMethod = tableType.GetMethod("GetEntry");
                var entryType = getEntryMethod.ReturnType;
                FieldInfo entryField = null;

                // limit, offset, and field filters
                // limit in query string limits the results to that many entries
                int limit = -1;
                int offset = 0;

                var createFilter = (string name, string value) =>
                {
                    var field = entryType.GetField(name);
                    if (field == null)
                    {
                        throw new InvalidFilterCriteriaException(string.Format("Unknown field: {0}", name));
                    }
                    return (object entry) =>
                    {
                        var testString = string.Format("{0}", field.GetValue(entry));
                        return testString == value;
                    };
                };

                List<Func<object, bool>> filters = new List<Func<object, bool>>();

                foreach (var item in Request.Query)
                {
                    if (item.Key == "limit")
                    {
                        int.TryParse(item.Value, out limit);
                        continue;
                    }
                    if (item.Key == "offset")
                    {
                        int.TryParse(item.Value, out offset);
                        continue;
                    }
                    filters.Add(createFilter(item.Key, item.Value));
                }

                // process the table into results, using table's 'lookup'
                // property for index values
                var lookupField = tableType.GetField("lookup");
                int[] lookup = lookupField.GetValue(tableValue) as int[];
                Dictionary<int, object> results = new Dictionary<int, object>();
                int count = 0;
                int skipped = 0;
                for (int i = 0; i < lookup.Length; i++)
                {
                    if (lookup[i] < 0)
                    {
                        continue;
                    }
                    if (offset > 0 && skipped < offset)
                    {
                        skipped++;
                        continue;
                    }
                    object[] parms = { (ulong)i };
                    var value = getEntryMethod.Invoke(tableValue, parms);

                    bool matched = true;
                    foreach (var filter in filters)
                    {
                        if (!filter(value))
                        {
                            matched = false;
                            break;
                        }
                    }
                    if (!matched)
                    {
                        skipped++;
                        continue;
                    }

                    results[i] = value;
                    count++;
                    if (limit > 0 && limit <= count)
                    {
                        break;
                    }
                }

                // serialize results and include fields
                var json = JsonSerializer.Serialize(results, new JsonSerializerOptions() { IncludeFields = true });
                return Content(json, "application/json");
            }
            catch (InvalidFilterCriteriaException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Return an individual entry given table name and entry id
        /// </summary>
        /// <param name="tableName">Name of the table (property on GameTableManager)</param>
        /// <param name="id">Id of the entry to return</param>
        /// <returns>A single entry</returns>
        [HttpGet("{tableName}/{id}")]
        public IActionResult GetEntry(string tableName, uint id)
        {
            var property = typeof(GameTableManager).GetProperty(tableName);
            var tableValue = property.GetValue(GameTableManager.Instance);
            if (tableValue == null)
            {
                return null;
            }
            var tableType = tableValue.GetType();
            var getEntryMethod = tableType.GetMethod("GetEntry");
            object[] os = { id };
            var entryValue = getEntryMethod.Invoke(tableValue, os);
            var json = JsonSerializer.Serialize(entryValue, new JsonSerializerOptions() { IncludeFields = true });
            return Content(json, "application/json");
        }
    }
}
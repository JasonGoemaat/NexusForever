using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Logging;
using NexusForever.GameTable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexusForever.WorldServer.Api
{
    [ApiController]
    [Route("[controller]")]
    public class TextController : ControllerBase
    {
        private readonly ILogger<TextController> _logger;

        public TextController(ILogger<TextController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Return mapping of ids to text when an array of ids is passed.  More efficient
        /// than getting each text individually, but going away from use because we
        /// can get all texts fairly easily.
        /// </summary>
        /// <param name="ids">Array of ids to find text for</param>
        /// <returns>Mapping of id to text string</returns>
        [HttpPost]
        public IEnumerable<string> PostMultiple([FromBody] uint[] ids)
        {
            string[] results = new string[ids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                results[i] = GameTableManager.Instance.TextEnglish.GetEntry(ids[i]);
            }
            return results;
        }

        /// <summary>
        /// Return all localized texts for english.
        /// </summary>
        /// <returns>Mapping of id to text strings for all texts</returns>
        [HttpGet("all")]
        public Dictionary<int, string> GetAll()
        {
            Dictionary<int, string> texts = new Dictionary<int, string>();
            var tbl = GameTableManager.Instance.TextEnglish;
            for (int i = 0; i < tbl.lookup.Length; i++)
            {
                var id = tbl.lookup[i];
                if (id >= 0)
                {
                    texts.Add(i, tbl.GetEntry((uint)i));
                }
            }
            return texts;

        }

        /// <summary>
        /// Return the text for an individual id
        /// </summary>
        /// <param name="id">LocalizedTextId to find</param>
        /// <returns>The string English value for the given LocalizedTextId</returns>
        [HttpGet("{id}")]
        public string Get(uint id)
        {
            string text = GameTableManager.Instance.TextEnglish.GetEntry(id);
            var entry2 = GameTableManager.Instance.LocalizedText.GetEntry(id);
            if (text == null)
            {
                if (entry2 == null)
                {
                    return $"NULL for text id {id}";
                }
                return $"NULL for text id {id}, but found LocalizedText";
            }
            return text;
        }
    }
}
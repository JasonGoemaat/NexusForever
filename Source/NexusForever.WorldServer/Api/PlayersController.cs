using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NexusForever.Database.Character.Model;
using NexusForever.Network.Session;
using NexusForever.WorldServer.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NexusForever.WorldServer.Api
{
    /// <summary>
    /// Controller for returning information on logged-in players
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        INetworkManager<IWorldSession> networkManager;

        public PlayersController(ILogger<PlayersController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            this.networkManager = WorldServerApi.Services.GetRequiredService<INetworkManager<IWorldSession>>();
        }

        /// <summary>
        /// Return a list of all players currently playing the game
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            string json = String.Empty;
            await ApiManager.Instance.Run(() =>
            {
                var sessions = networkManager.ToList();
                var players = sessions.Select(x => new
                {
                    sessionId = x.Id,
                    characterId = x.Player.CharacterId,
                    name = x.Player.Name,
                    race = x.Player.Race,
                    @class = x.Player.Class,
                    sex = x.Player.Sex,
                    level = x.Player.Level
                }).ToList();

                JsonSerializerOptions options = new JsonSerializerOptions();
                json = JsonSerializer.Serialize(players, options);
            });
            return Content(json, "application/json");
        }

        /// <summary>
        /// Return information for an individual player identified by character id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{characterId}")]
        public async Task<IActionResult> Get(ulong characterId)
        {
            string json = String.Empty;
            await ApiManager.Instance.Run(() =>
            {
                var session = networkManager.FirstOrDefault(x => x?.Player?.CharacterId == characterId);
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.IncludeFields = true;
                options.WriteIndented = true;
                options.Converters.Add(new JsonIgnoreConverter<Game.Map.BaseMap>()); // HUGE amount of data
                options.Converters.Add(new JsonIgnoreConverter<List<CharacterModel>>()); // Lots of data
                //options.Converters.Add(new JsonIgnoreConverter<Game.Account.AccountInventory>()); // ~720 lines
                options.Converters.Add(new JsonIgnoreConverter<Game.Entity.Inventory>()); // ~5700 lines // would be nice, but lots of data
                json = JsonSerializer.Serialize(session.Player, options);
            });
            return Content(json, "application/json");
        }

        /// <summary>
        /// For development/debug purposes only, return a large amount of information for all players,
        /// ignoring only some larger fields (espeically the map) that aren't useful.
        /// </summary>
        /// <returns></returns>
        [HttpGet("debug")]
        public async Task<IActionResult> GetDebug()
        {
            string json = String.Empty;
            await ApiManager.Instance.Run(() =>
            {
                var sessions = networkManager.ToList();
                var players = sessions.Select(x => x.Player).ToList();

                /*
                // for testing to see paths, types, and properties
                if (players.Count > 0)
                {
                    var player = players[0];
                    var questManager = player.QuestManager; // has fields, important were private
                    var position = player.Position;
                    var accountInventory = player.Session.AccountInventory; // lots of lines
                    var inventory = player.Inventory; // about 5700 lines
                    var completedQuests = player.QuestManager.completedQuests; // ~12k lines, can we ignore?
                }
                */

                // Ignore some types we don't care about, or that are too large
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.IncludeFields = true;
                options.WriteIndented = true;

                options.Converters.Add(new JsonIgnoreConverter<Game.Map.BaseMap>()); // HUGE amount of data
                options.Converters.Add(new JsonIgnoreConverter<List<CharacterModel>>()); // Lots of data
                //options.Converters.Add(new JsonIgnoreConverter<Game.Account.AccountInventory>()); // ~720 lines
                options.Converters.Add(new JsonIgnoreConverter<Game.Entity.Inventory>()); // ~5700 lines // would be nice, but lots of data

                json = JsonSerializer.Serialize(players, options);
            });
            return Content(json, "application/json");
        }
    }

    /// <summary>
    /// Class to allow us to ignore properties that take a lot of time to serialize
    /// or inflate the size of the response too much.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonIgnoreConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return default(T);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteNullValue();
        }
    }
}

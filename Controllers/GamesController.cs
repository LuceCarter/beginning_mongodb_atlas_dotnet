using beginning_mongodb_atlas_dotnet.Models;
using beginning_mongodb_atlas_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace beginning_mongodb_atlas_dotnet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesDatabaseService _gameService;

        public GamesController(GamesDatabaseService gamesService)
        {
            _gameService = gamesService;
        }

        [HttpGet]
        public ActionResult<List<Game>> Get() =>
            _gameService.Get();

        [HttpGet("{id:length(24)}", Name = "GetGame")]
        public ActionResult<Game> Get(string id)
        {
            var game = _gameService.GetOne(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost("CreateOne")]
        public ActionResult<Game> Create(Game game)
        {
            _gameService.CreateOne(game);

            return Ok();
        }

        [HttpPost("CreateMany")]
        public ActionResult<Game> CreateMany(Game[] games)
        {
            _gameService.CreateMany(games);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Game gameIn)
        {
            var game = _gameService.GetOne(id);

            if (game == null)
            {
                return NotFound();
            }

            _gameService.UpdateOne(id, gameIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}"),]
        public IActionResult DeleteOne(string id)
        {
            var game = _gameService.GetOne(id);

            if (game == null)
            {
                return NotFound();
            }

            _gameService.DeleteOne(game.Id);

            return NoContent();
        }
    }
}

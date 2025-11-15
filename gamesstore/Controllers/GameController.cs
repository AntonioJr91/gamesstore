using gamesstore.DTOs;
using gamesstore.DTOs.Mapping;
using gamesstore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace gamesstore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public GameController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult<GameDTO> GetAll()
        {
            var games = _uow.Games.GetAll();
            var gamesDTO = games.ToGameDTOList();
            return Ok(gamesDTO);
        }

        [HttpGet("{id:int}")]
        public ActionResult<GameDTO> GetById(int id)
        {
            var game = _uow.Games.GetBy(g => g.Id == id);

            if (game is null) return NotFound("Game not found!");

            var gameDTO = game.ToGameDTO();
            return Ok(gameDTO);
        }

        [HttpPost]
        public ActionResult<GameDTO> Post(GameDTO gameDTO)
        {
            if (gameDTO is null) return BadRequest("Invalid game data. Please check the submitted fields.");

            var category = _uow.Categories.GetBy(c => c.Id == gameDTO.CategoryId);

            if (category is null) return BadRequest("The category with this ID does not exist.");

            var game = gameDTO.ToGame();
            var newGame = _uow.Games.Create(game);
            _uow.SaveChanges();

            var newGameDTO = newGame.ToGameDTO();
            return CreatedAtAction(nameof(GetById), new { id = newGameDTO.Id }, newGameDTO);
        }

        [HttpPut("{id:int}")]
        public ActionResult<GameDTO> Update(int id, GameDTO gameDTO)
        {
            if (id != gameDTO.Id) return BadRequest("Route ID and body ID must match.");

            var game = _uow.Games.GetBy(g => g.Id == id);

            if (game is null) return NotFound("Game not found!");

            game.Update(gameDTO.Name, gameDTO.Price, gameDTO.PublicationDate);
            _uow.SaveChanges();

            var updatedGameDTO = game.ToGameDTO();
            return Ok(updatedGameDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GameDTO> Delete(int id)
        {
            var game = _uow.Games.GetBy(g => g.Id == id);

            if (game is null) return NotFound();

            var deletedGame = _uow.Games.Delete(game);
            _uow.SaveChanges();

            var deletedGameDTO = deletedGame.ToGameDTO();
            return Ok(deletedGameDTO);
        }
    }
}

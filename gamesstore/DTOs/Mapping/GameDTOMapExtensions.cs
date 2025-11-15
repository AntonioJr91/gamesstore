using gamesstore.Domain;

namespace gamesstore.DTOs.Mapping
{
    public static class GameDTOMapExtensions
    {
        public static GameDTO ToGameDTO(this Game game)
        {
            return new GameDTO()
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                CategoryId = game.CategoryId,
                PublicationDate = game.PublicationDate,
                Created_At = game.Created_At,
            };
        }

        public static Game ToGame(this GameDTO gameDTO)
        {
            return new Game(
                id: gameDTO.Id,
                name: gameDTO.Name,
                price: gameDTO.Price,
                publicationDate: gameDTO.PublicationDate,
                categoryId: gameDTO.CategoryId
            );
        }

        public static IEnumerable<GameDTO> ToGameDTOList(this IEnumerable<Game> games)
        {
            if (games is null)
                return Enumerable.Empty<GameDTO>();

            return games.Select(g => new GameDTO
            {
                Id = g.Id,
                Name = g.Name,
                Price = g.Price,
                Created_At = g.Created_At,
                PublicationDate = g.PublicationDate,
                CategoryId = g.CategoryId,
            }).ToList();
        }
    }
}

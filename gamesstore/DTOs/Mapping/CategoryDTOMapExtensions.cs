using gamesstore.Domain;

namespace gamesstore.DTOs.Mapping
{
    public static class CategoryDTOMapExtensions
    {
        public static CategoryDTO ToCategoryDTO(this Category category)
        {
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public static Category ToCategory(this CategoryDTO categoryDTO)
        {
            return new Category(name: categoryDTO.Name);
        }

        public static IEnumerable<CategoryDTO> ToCategoryDTOList(this IEnumerable<Category> categories)
        {
            if (categories is null)
                return Enumerable.Empty<CategoryDTO>();

            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }
    }
}

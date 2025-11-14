using gamesstore.DTOs;
using gamesstore.DTOs.Mapping;
using gamesstore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace gamesstore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = _uow.Categories.GetAll();

            var categoriesDTO = categories.ToCategoryDTOList();

            return Ok(categoriesDTO);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CategoryDTO> GetById(int id)
        {
            var category = _uow.Categories.GetBy(c => c.Id == id);

            if (category is null) return NotFound("Category not found!");

            var categoryDTO = category.ToCategoryDTO();
            return Ok(categoryDTO);
        }

        [HttpPost]
        public ActionResult<CategoryDTO> Post(CategoryDTO categoryDTO)
        {
            if (categoryDTO is null) return BadRequest("Invalid category data. Please check the submitted fields.");

            var category = categoryDTO.ToCategory();
            var newCategory = _uow.Categories.Create(category);
            _uow.SaveChanges();

            var newCategoryDTO = newCategory.ToCategoryDTO();
            return CreatedAtAction(nameof(GetById), new { id = newCategoryDTO.Id }, newCategoryDTO);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoryDTO> Update(int id, CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id) return BadRequest("Route ID and body ID must match.");

            var category = _uow.Categories.GetBy(c => c.Id == id);

            if (category is null) return NotFound("Category not found!");

            category.Update(categoryDTO.Name);
            _uow.SaveChanges();

            var updatedCategoryDTO = category.ToCategoryDTO();
            return Ok(updatedCategoryDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CategoryDTO> Delete(int id)
        {
            var category = _uow.Categories.GetBy(c => c.Id == id);

            if (category is null) return NotFound("Category not found!");

            var deletedCategoryDTO = category.ToCategoryDTO();

            _uow.Categories.Delete(category);
            _uow.SaveChanges();

            return Ok(deletedCategoryDTO);
        }
    }
}

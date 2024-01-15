using AutoMapper;
using E_Commerce_Website.API.Models;
using E_Commerce_Website.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }


        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepo.Get();
            if (categories == null || !categories.Any())
            {
                return NotFound();
            }

            var categoriesDto = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return Ok(categoriesDto);
        }
        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepo.GetById(id);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            var categoryDto = _mapper.Map<CategoryViewModel>(category);
            return Ok(categoryDto);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryViewModel viewCategory)
        {
            if (viewCategory != null)
            {
                var category = _mapper.Map<Category>(viewCategory);
                await _categoryRepo.Add(category);
                 _categoryRepo.SaveChangesAsync();

                return Ok();
            }
            else
            {

                return StatusCode(500, "An error occurred while saving changes to the database.");
            }
        }

        [HttpPost("EditCategory/{id}")]
        public async Task<IActionResult> EditCategory(int id, [FromBody] CategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = await _categoryRepo.GetById(id);

                if (existingCategory == null)
                {
                    return NotFound("Category not found");
                }

                // Update properties of the existingCategory with the values from categoryModel
                _mapper.Map(categoryModel, existingCategory);

                await _categoryRepo.SaveChangesAsync();

                return Ok();
            }

            // If model state is not valid, return BadRequest with validation errors
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepo.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepo.Delete(id);
            _categoryRepo.SaveChangesAsync();

            return RedirectToAction(nameof(GetAllCategories));
        }
    }
}
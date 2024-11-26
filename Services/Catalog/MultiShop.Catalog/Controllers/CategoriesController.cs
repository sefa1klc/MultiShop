using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryServices.Abstract;

namespace MultiShop.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var value = await _categoryService.GetAllAsync();
        return Ok(value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var value = await _categoryService.GetByIdAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        await _categoryService.CreateAsync(categoryDto);
        return Ok("Category successfully created");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteAsync(id);
        return Ok("Category successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        await _categoryService.UpdateAsync(categoryDto);
        return Ok("Category successfully updated");
    }
}
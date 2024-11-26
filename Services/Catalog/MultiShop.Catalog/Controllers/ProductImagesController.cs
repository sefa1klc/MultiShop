using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices.Abstract;

namespace MultiShop.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageService _productImageService;

    public ProductImagesController(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var value = await _productImageService.GetAllAsync();
        return Ok(value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var value = await _productImageService.GetByIdAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateProductImageDto productImageDto)
    {
        await _productImageService.CreateAsync(productImageDto);
        return Ok("Product image successfully created");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _productImageService.DeleteAsync(id);
        return Ok("Product image successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateProductImageDto productImageDto)
    {
        await _productImageService.UpdateAsync(productImageDto);
        return Ok("Product image successfully updated");
    }
}
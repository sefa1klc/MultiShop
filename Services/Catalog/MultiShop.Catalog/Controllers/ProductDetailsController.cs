using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Services.ProductDetailServices.Abstract;

namespace MultiShop.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductDetailsController : ControllerBase
{
    private readonly IProductDetailService _productDetailService;

    public ProductDetailsController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var value = await _productDetailService.GetAllAsync();
        return Ok(value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var value = await _productDetailService.GetByIdAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateProductDetailDto productDetailDto)
    {
        await _productDetailService.CreateAsync(productDetailDto);
        return Ok("Product Detail successfully created");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _productDetailService.DeleteAsync(id);
        return Ok("Product Detail successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateProductDetailDto productDetailDto)
    {
        await _productDetailService.UpdateAsync(productDetailDto);
        return Ok("Product Detail successfully updated");
    }
}
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices.Abstract;

namespace MultiShop.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var value = await _productService.GetAllAsync();
        return Ok(value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var value = await _productService.GetByIdAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
    {
        await _productService.CreateAsync(productDto);
        return Ok("Product successfully created");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteAsync(id);
        return Ok("Product successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
    {
        await _productService.UpdateAsync(productDto);
        return Ok("Product successfully updated");
    }
}
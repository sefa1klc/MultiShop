using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CoreServices;

namespace MultiShop.Catalog.Services.ProductServices.Abstract;

public interface IProductService : IGenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>
{
    
}
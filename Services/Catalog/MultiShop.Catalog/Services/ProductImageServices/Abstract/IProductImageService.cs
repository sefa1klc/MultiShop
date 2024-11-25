using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CoreServices;

namespace MultiShop.Catalog.Services.ProductImageServices.Abstract;

public interface IProductImageService : 
    IGenericService<ProductImage, CreateProductImageDto, UpdateProductImageDto, GetByIdProductImageDto, ResultProductImageDto>
{
    
}
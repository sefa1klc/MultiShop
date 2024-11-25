using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CoreServices;

namespace MultiShop.Catalog.Services.ProductDetailServices.Abstract;

public interface IProductDetailService : 
    IGenericService<ProductDetail, CreateProductDetailDto, UpdateProductDetailDto, GetByIdProductDetailDto, ResultProductDetailDto>
{
    
}
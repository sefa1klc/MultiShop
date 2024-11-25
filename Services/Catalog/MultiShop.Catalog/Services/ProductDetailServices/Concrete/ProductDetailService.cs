using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CoreServices;
using MultiShop.Catalog.Services.ProductDetailServices.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices.Concrete;

public class ProductDetailService : 
    GenericService<ProductDetail, CreateProductDetailDto, UpdateProductDetailDto, GetByIdProductDetailDto, ResultProductDetailDto>, IProductDetailService
{
    public ProductDetailService(IDatabaseSettings databaseSettings, IMapper mapper) 
        : base(new MongoClient(databaseSettings.ConnectionString)
            .GetDatabase(databaseSettings.DatabaseName)
            .GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName), mapper)
    {
    }
}
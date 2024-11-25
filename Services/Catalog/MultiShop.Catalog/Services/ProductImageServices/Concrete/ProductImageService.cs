using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CoreServices;
using MultiShop.Catalog.Services.ProductImageServices.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices.Concrete;

public class ProductImageService : 
    GenericService<ProductImage, CreateProductImageDto, UpdateProductImageDto, GetByIdProductImageDto, ResultProductImageDto>, IProductImageService
{
    public ProductImageService(IDatabaseSettings databaseSettings, IMapper mapper) 
        : base(new MongoClient(databaseSettings.ConnectionString)
            .GetDatabase(databaseSettings.DatabaseName)
            .GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName), mapper)
    {
    }
}
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CoreServices;
using MultiShop.Catalog.Services.ProductServices.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices.Concrete;

public class ProductService : 
    GenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>, IProductService
{
    public ProductService(IDatabaseSettings databaseSettings, IMapper mapper) 
        : base(new MongoClient(databaseSettings.ConnectionString)
            .GetDatabase(databaseSettings.DatabaseName)
            .GetCollection<Product>(databaseSettings.ProductCollectionName), mapper)
    {
    }
}

using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryServices.Abstract;
using MultiShop.Catalog.Services.CoreServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices.Concrete;

public class CategoryService : GenericService<Category, CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto, ResultCategoryDto>, ICategoryService
{
    public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper) 
        : base(new MongoClient(databaseSettings.ConnectionString)
            .GetDatabase(databaseSettings.DatabaseName)
            .GetCollection<Category>(databaseSettings.CategoryCollectionName), mapper)
    {
    }
}

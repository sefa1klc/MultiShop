
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CoreServices;

namespace MultiShop.Catalog.Services.CategoryServices.Abstract;

public interface ICategoryService : IGenericService<Category,CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto, ResultCategoryDto>
{
}
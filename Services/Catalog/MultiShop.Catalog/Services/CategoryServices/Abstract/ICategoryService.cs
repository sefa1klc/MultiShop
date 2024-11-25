
using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices.Abstract;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task CreateCategory(CreateCategoryDto createCategoryDto);
    Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategory(string categoryId);
    Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId);
}
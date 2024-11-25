namespace MultiShop.Catalog.Services.CoreServices;

public interface IGenericService<T, TCreateDto, TUpdateDto, TGetByIdDto, TResultDto>
{
    Task<List<TResultDto>> GetAllAsync();
    Task CreateAsync(TCreateDto createDto);
    Task UpdateAsync(TUpdateDto updateDto);
    Task DeleteAsync(string id);
    Task<TGetByIdDto> GetByIdAsync(string id);
}
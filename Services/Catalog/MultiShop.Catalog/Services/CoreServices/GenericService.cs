using AutoMapper;
using MongoDB.Driver;

namespace MultiShop.Catalog.Services.CoreServices;

public class GenericService<T, TCreateDto, TUpdateDto, TGetByIdDto, TResultDto> 
    : IGenericService<T, TCreateDto, TUpdateDto, TGetByIdDto, TResultDto>
{
    private readonly IMongoCollection<T> _collection;
    private readonly IMapper _mapper;
    private readonly string _idFieldName;

    public GenericService(IMongoCollection<T> collection, IMapper mapper, string idFieldName)
    {
        _collection = collection;
        _mapper = mapper;
        _idFieldName = idFieldName;
    }

    public async Task<List<TResultDto>> GetAllAsync()
    {
        var entities = await _collection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<TResultDto>>(entities);
    }

    public async Task CreateAsync(TCreateDto createDto)
    {
        var entity = _mapper.Map<T>(createDto);
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(TUpdateDto updateDto)
    {
        var entity = _mapper.Map<T>(updateDto);

        var id = typeof(T).GetProperty(_idFieldName)?.GetValue(entity)?.ToString();
        if (id == null) throw new Exception($"ID not found for field {_idFieldName}");

        var filter = Builders<T>.Filter.Eq(_idFieldName, id);
        await _collection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_idFieldName, id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<TGetByIdDto> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_idFieldName, id);
        var entity = await _collection.Find(filter).FirstOrDefaultAsync();
        return _mapper.Map<TGetByIdDto>(entity);
    }
}
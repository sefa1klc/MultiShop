using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Services.Concrete;

public class DiscountService : IDiscountService
{
    private readonly DiscountDapperContext _context;

    public DiscountService(DiscountDapperContext discountDapperContext)
    {
        _context = discountDapperContext;
    }

    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
    {
        string query = @"select * from Coupons";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
            return values.ToList();
        }
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
    {
        string query = @"INSERT INTO Coupons (CouponCode, CouponRate, IsActive, CouponValidDate) VALUES (@code, @rate, @isActive, @valiDdate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createDiscountCouponDto.CouponCode);
        parameters.Add("@rate", createDiscountCouponDto.CouponRate);
        parameters.Add("@isActive", createDiscountCouponDto.IsActive);
        parameters.Add("@valiDdate", createDiscountCouponDto.CouponValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
    {
        string query = @"UPDATE Coupons SET CouponCode =@code, CouponRate = @rate, IsActive = @isActive, CouponValidDate = @valiDdate WHERE CouponID = @couponID";
        var parameters = new DynamicParameters();
        parameters.Add("@code", updateDiscountCouponDto.CouponCode);
        parameters.Add("@rate", updateDiscountCouponDto.CouponRate);
        parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
        parameters.Add("@valiDdate", updateDiscountCouponDto.CouponValidDate);
        parameters.Add("@couponID", updateDiscountCouponDto.CouponID);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }    
    }

    public async Task DeleteDiscountCouponAsync(int id)
    {
        string query = @"DELETE FROM Coupons WHERE CouponID = @id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
    {
        string query = @"select * from Coupons where CouponID = @id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QuerySingleOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
            return value;
        }
    }
}
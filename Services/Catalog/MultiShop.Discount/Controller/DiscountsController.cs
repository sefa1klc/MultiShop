using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Controller;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDiscountCoupons()
    {
        var coupons = await _discountService.GetAllDiscountCouponAsync();
        return Ok( coupons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountCouponById(int id)
    {
        var coupon = await _discountService.GetByIdDiscountCouponAsync(id);
        return Ok(coupon);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupons(UpdateDiscountCouponDto updateDiscountCouponDto)
    { 
        await _discountService.UpdateDiscountCouponAsync(updateDiscountCouponDto);
        return Ok("Coupon successfully updated");
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
    {
        await _discountService.CreateDiscountCouponAsync(createDiscountCouponDto);
        return Ok("coupon successfully created");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDiscountCoupon(int id)
    {
        await _discountService.DeleteDiscountCouponAsync(id);
        return Ok("Coupon successfully deleted");
    }
}
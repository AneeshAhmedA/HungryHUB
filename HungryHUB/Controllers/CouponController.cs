using AutoMapper;
using HungryHUB.DTO;
using HungryHUB.Entity;
using HungryHUB.Service;
using Microsoft.AspNetCore.Mvc;
namespace HungryHUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly IMapper _mapper;

        public CouponController(ICouponService couponService, IMapper mapper)
        {
            _couponService = couponService;
            _mapper = mapper;
        }

        [HttpGet, Route("GetAllCoupons")]
        public IActionResult GetAllCoupons()
        {
            try
            {
                List<Coupon> coupons = _couponService.GetAllCoupons();
                List<CouponDTO> couponDTOs = _mapper.Map<List<CouponDTO>>(coupons);
                return StatusCode(200, couponDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetCouponById/{couponId}")]
        public IActionResult GetCouponById(int couponId)
        {
            try
            {
                var coupon = _couponService.GetCouponById(couponId);

                if (coupon == null)
                {
                    return StatusCode(404);
                }

                var couponDTO = _mapper.Map<CouponDTO>(coupon);
                return StatusCode(200, couponDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("CreateCoupon")]
        public IActionResult CreateCoupon([FromBody] CouponDTO couponDTO)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDTO);
                _couponService.CreateCoupon(coupon);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("DeleteCoupon/{couponId}")]
        public IActionResult DeleteCoupon(int couponId)
        {
            var existingCoupon = _couponService.GetCouponById(couponId);

            if (existingCoupon == null)
            {
                return StatusCode(404); 
            }

            _couponService.DeleteCoupon(couponId);

            return StatusCode(200); 
        }
    }
}

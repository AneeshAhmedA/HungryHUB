using AutoMapper;
using HungryHUB.DTO;
using HungryHUB.Entity;
using HungryHUB.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryHUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;

        public CityController(ICityService cityService, IMapper mapper, IConfiguration configuration)
        {
            this.cityService = cityService;
            _mapper = mapper;
            this.configuration = configuration;
        }
        //end points
        //GET /GetAllCities
        [HttpGet, Route("GetAllCities")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            try
            {
                List<City> Cities = cityService.GetAllCities();
                List<CityDTO> citiesDto = _mapper.Map<List<CityDTO>>(Cities);
                return StatusCode(200, citiesDto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //POST /AddCity
        [Authorize(Roles = "Admin")]
        [HttpPost, Route("AddCity")]
        public IActionResult Add([FromBody] CityDTO cityDto)
        {
            try
            {
                City city = _mapper.Map<City>(cityDto);
                cityService.CreateCity(city);
                return StatusCode(200, city);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //PUT /EditCity
        [HttpPut, Route("EditCity")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCity(CityDTO cityDto)
        {
            try
            {
                City city = _mapper.Map<City>(cityDto);
                cityService.EditCity(city);
                return StatusCode(200, city);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //Delete /DeleteCity
        [HttpDelete, Route("DeleteCity/{cityID}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCity(long cityID)
        {
            try
            {
                cityService.DeleteCity(cityID);
                return StatusCode(200, new JsonResult($"Product with Id {cityID} is Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

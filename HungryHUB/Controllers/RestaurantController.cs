using AutoMapper;
using HungryHUB.DTO;
using HungryHUB.Entity;
using HungryHUB.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace HungryHUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public RestaurantController(IRestaurantService restaurantService, IMapper mapper, IConfiguration configuration)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
            _configuration = configuration;
        }

        // GET: /api/Restaurant
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            try
            {
                List<Restaurant> restaurants = _restaurantService.GetAllRestaurants();
                List<RestaurantDTO> restaurantDTOs = _mapper.Map<List<RestaurantDTO>>(restaurants);
                return StatusCode(200, restaurantDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: /api/Restaurant/{id}
        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            try
            {
                Restaurant restaurant = _restaurantService.GetRestaurantById(id);

                if (restaurant == null)
                {
                    return NotFound();
                }

                RestaurantDTO restaurantDTO = _mapper.Map<RestaurantDTO>(restaurant);
                return Ok(restaurantDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: /api/Restaurant
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateRestaurant([FromBody] RestaurantDTO restaurantDTO)
        {
            try
            {
                Restaurant restaurant = _mapper.Map<Restaurant>(restaurantDTO);
                _restaurantService.CreateRestaurant(restaurant);
                return Ok(); // Return 200 OK for success
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: /api/Restaurant/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Example authorization, adjust as needed
        public IActionResult UpdateRestaurant(int id, [FromBody] RestaurantDTO restaurantDTO)
        {
            try
            {
                Restaurant existingRestaurant = _restaurantService.GetRestaurantById(id);

                if (existingRestaurant == null)
                {
                    return NotFound();
                }

                _mapper.Map(restaurantDTO, existingRestaurant);
                _restaurantService.UpdateRestaurant(id, existingRestaurant);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: /api/Restaurant/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Example authorization, adjust as needed
        public IActionResult DeleteRestaurant(int id)
        {
            try
            {
                Restaurant existingRestaurant = _restaurantService.GetRestaurantById(id);

                if (existingRestaurant == null)
                {
                    return NotFound();
                }

                _restaurantService.DeleteRestaurant(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

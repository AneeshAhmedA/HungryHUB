using AutoMapper;
using HungryHUB.DTO;
using HungryHUB.Entity;
using HungryHUB.Service;
using Microsoft.AspNetCore.Mvc;

namespace HungryHUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IMapper _mapper;

        public MenuItemController(IMenuItemService menuItemService, IMapper mapper)
        {
            _menuItemService = menuItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MenuItemDTO>> GetAllMenuItems()
        {
            var menuItems = _menuItemService.GetAllMenuItems();
            var menuItemDTOs = _mapper.Map<List<MenuItemDTO>>(menuItems);
            return StatusCode(200, menuItemDTOs);
        }

        [HttpGet("{menuItemId}")]
        public ActionResult<MenuItemDTO> GetMenuItemById(string menuItemId)
        {
            var menuItem = _menuItemService.GetMenuItemById(menuItemId);

            if (menuItem == null)
            {
                return StatusCode(404);
            }

            var menuItemDTO = _mapper.Map<MenuItemDTO>(menuItem);
            return StatusCode(200, menuItemDTO);
        }

        [HttpGet("ByRestaurant/{restaurantId}")]
        public ActionResult<IEnumerable<MenuItemDTO>> GetMenuItemsByRestaurant(int restaurantId)
        {
            var menuItems = _menuItemService.GetMenuItemsByRestaurant(restaurantId);
            var menuItemDTOs = _mapper.Map<List<MenuItemDTO>>(menuItems);
            return StatusCode(200, menuItemDTOs);
        }

        [HttpPost]
        public ActionResult CreateMenuItem([FromBody] MenuItemDTO menuItemDTO)
        {
            try
            {
                var menuItem = _mapper.Map<MenuItem>(menuItemDTO);
                _menuItemService.CreateMenuItem(menuItem);
                return StatusCode(200); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{menuItemId}")]
        public ActionResult UpdateMenuItem(string menuItemId, [FromBody] MenuItemDTO menuItemDTO)
        {
            try
            {
                var existingMenuItem = _menuItemService.GetMenuItemById(menuItemId);

                if (existingMenuItem == null)
                {
                    return StatusCode(404); 
                }

                var updatedMenuItem = _mapper.Map<MenuItem>(menuItemDTO);
                _menuItemService.UpdateMenuItem(menuItemId, updatedMenuItem);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{menuItemId}")]
        public ActionResult DeleteMenuItem(string menuItemId)
        {
            var existingMenuItem = _menuItemService.GetMenuItemById(menuItemId);

            if (existingMenuItem == null)
            {
                return StatusCode(404); 
            }

            _menuItemService.DeleteMenuItem(menuItemId);

            return StatusCode(204);
        }
    }
}

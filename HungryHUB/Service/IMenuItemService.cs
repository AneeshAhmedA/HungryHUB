
using HungryHUB.Entity;
namespace HungryHUB.Service
{
    public interface IMenuItemService
    {
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(string menuItemId);
        List<MenuItem> GetMenuItemsByRestaurant(int restaurantId);
        void CreateMenuItem(MenuItem menuItem);
        void UpdateMenuItem(string menuItemId, MenuItem updatedMenuItem);
        void DeleteMenuItem(string menuItemId);
    }
}

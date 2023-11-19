using HungryHUB.Entity;

namespace HungryHUB.Service
{
    public interface IRestaurantService
    {
        Restaurant GetRestaurantById(int restaurantId);
        List<Restaurant> GetAllRestaurants();
        void CreateRestaurant(Restaurant restaurant);
        void UpdateRestaurant(int restaurantId, Restaurant updatedRestaurant);
        void DeleteRestaurant(int restaurantId);
    }
}

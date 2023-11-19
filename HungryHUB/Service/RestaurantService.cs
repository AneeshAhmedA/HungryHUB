using System;
using System.Collections.Generic;
using HungryHUB.Database;
using HungryHUB.Entity;

namespace HungryHUB.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly MyContext _context;

        public RestaurantService(MyContext context)
        {
            _context = context;
        }

     
        public List<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return _context.Restaurants.Find(restaurantId);
        }


        public void UpdateRestaurant(int restaurantId, Restaurant updatedRestaurant)
        {
            var existingRestaurant = _context.Restaurants.Find(restaurantId);

            if (existingRestaurant != null)
            {
                existingRestaurant.Name = updatedRestaurant.Name;
                existingRestaurant.City = updatedRestaurant.City;
                // Update other properties as needed
                _context.Restaurants.Update(existingRestaurant);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Restaurant with ID {restaurantId} not found.");
            }
        }

        public void DeleteRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        void IRestaurantService.CreateRestaurant(Restaurant restaurant)
        {
            try
            {
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

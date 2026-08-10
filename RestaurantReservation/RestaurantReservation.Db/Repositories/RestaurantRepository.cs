using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public static class RestaurantRepository
{
    public static async Task<int> Create(Restaurant restaurant)
    {
        await using var context = new RestaurantReservationDbContext();
        await context.Restaurants.AddAsync(restaurant);
        await context.SaveChangesAsync();

        return restaurant.RestaurantId;
    }
    
    public static async Task<int?> Update(Restaurant updatedRestaurant)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingRestaurant = await context.Restaurants.FindAsync(updatedRestaurant.RestaurantId);

        if (existingRestaurant == null) return null;
        existingRestaurant.Name = updatedRestaurant.Name;
        existingRestaurant.Address = updatedRestaurant.Address;
        existingRestaurant.PhoneNumber = updatedRestaurant.PhoneNumber;
        existingRestaurant.OpeningHours = updatedRestaurant.OpeningHours;
        
        await context.SaveChangesAsync();
        return updatedRestaurant.RestaurantId;
    }
    
    public static async Task<int?> Delete(int id)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingRestaurant = await context.Restaurants.FindAsync(id);

        if (existingRestaurant == null) return null;
        context.Restaurants.Remove(existingRestaurant);
        
        await context.SaveChangesAsync();
        return id;
    }
}
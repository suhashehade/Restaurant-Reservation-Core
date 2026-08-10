using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public static class MenuItemRepository
{
    public static async Task<int> Create(MenuItem menuItem)
    {
        await using var context = new RestaurantReservationDbContext();
        await context.MenuItems.AddAsync(menuItem);
        await context.SaveChangesAsync();

        return menuItem.ItemId;
    }
    
    public static async Task<int?> Update(MenuItem updatedMenuItem)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingMenuItem = await context.MenuItems.FindAsync(updatedMenuItem.ItemId);

        if (existingMenuItem == null) return null;
        existingMenuItem.Name = updatedMenuItem.Name;
        existingMenuItem.Description = updatedMenuItem.Description;
        existingMenuItem.Price = updatedMenuItem.Price;
        
        await context.SaveChangesAsync();
        return updatedMenuItem.ItemId;
    }
    
    public static async Task<int?> Delete(int id)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingMenuItem = await context.MenuItems.FindAsync(id);

        if (existingMenuItem == null) return null;
        context.MenuItems.Remove(existingMenuItem);
        
        await context.SaveChangesAsync();
        return id;
    }
}
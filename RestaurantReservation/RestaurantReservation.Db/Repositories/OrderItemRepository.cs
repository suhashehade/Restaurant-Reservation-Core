using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public static class OrderItemRepository
{
    public static async Task<int> Create(OrderItem orderItem)
    {
        await using var context = new RestaurantReservationDbContext();
        await context.OrderItems.AddAsync(orderItem);
        await context.SaveChangesAsync();

        return orderItem.OrderItemId;
    }
    
    public static async Task<int?> Update(OrderItem updatedOrderItem)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingOrderItem = await context.OrderItems.FindAsync(updatedOrderItem.OrderItemId);

        if (existingOrderItem == null) return null;
        existingOrderItem.Quantity = updatedOrderItem.Quantity;
        
        await context.SaveChangesAsync();
        return updatedOrderItem.OrderItemId;
    }
    
    public static async Task<int?> Delete(int id)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingOrderItem = await context.OrderItems.FindAsync(id);

        if (existingOrderItem == null) return null;
        context.OrderItems.Remove(existingOrderItem);
        
        await context.SaveChangesAsync();
        return id;
    }
}
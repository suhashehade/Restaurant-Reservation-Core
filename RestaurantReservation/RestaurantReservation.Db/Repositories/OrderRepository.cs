using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public static class OrderRepository
{
    public static async Task<int> Create(Order order)
    {
        await using var context = new RestaurantReservationDbContext();
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();

        return order.OrderId;
    }
    
    public static async Task<int?> Update(Order updatedOrder)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingOrder = await context.Orders.FindAsync(updatedOrder.OrderId);

        if (existingOrder == null) return null;
        existingOrder.OrderDate = updatedOrder.OrderDate;
        existingOrder.TotalAmount = updatedOrder.TotalAmount;
        
        await context.SaveChangesAsync();
        return updatedOrder.OrderId;
    }
    
    public static async Task<int?> Delete(int id)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingOrder = await context.Orders.FindAsync(id);

        if (existingOrder == null) return null;
        context.Orders.Remove(existingOrder);
        
        await context.SaveChangesAsync();
        return id;
    }
}
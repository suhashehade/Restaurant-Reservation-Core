using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;


namespace RestaurantReservation.Db.Repositories;

public static class ReservationRepository
{
    
    public static async Task<int> Create(Reservation reservation)
    {
        await using var context = new RestaurantReservationDbContext();
        await context.Reservations.AddAsync(reservation);
        await context.SaveChangesAsync();

        return reservation.ReservationId;
    }
    
    public static async Task<Reservation?> Update(int reservationId, Reservation updatedReservation)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingReservation = await context.Reservations.FindAsync(reservationId);

        if (existingReservation == null) return null;
        existingReservation.ReservationDate = updatedReservation.ReservationDate;
        existingReservation.PartySize = updatedReservation.PartySize;
        
        await context.SaveChangesAsync();
        return updatedReservation;
    }
    
    public static async Task<int?> Delete(int id)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingReservation = await context.Reservations.FindAsync(id);

        if (existingReservation == null) return null;
        context.Reservations.Remove(existingReservation);
        
        await context.SaveChangesAsync();
        return id;
    }
    
    public static async Task<List<OrderWithMenuItemsDto>> ListOrdersAndMenuItems(int reservationId)
    {
        await using var context = new RestaurantReservationDbContext();

        return await context.Orders
            .Where(o => o.ReservationId == reservationId)
            .Select(o => new OrderWithMenuItemsDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,

                MenuItems = o.OrderItems
                    .Where(oi => oi.MenuItem != null)
                    .Select(oi => new OrderMenuItemDto
                    {
                        ItemId = oi.MenuItem!.ItemId,
                        Name = oi.MenuItem.Name,
                        Price = oi.MenuItem.Price,
                        Quantity = oi.Quantity
                    })
                    .ToList()
            })
            .ToListAsync();
    }
    
    public static async Task<List<MenuItem>> ListOrderedAndMenuItems(int reservationId)
    {
        await using var context = new RestaurantReservationDbContext();
        return await context.Orders
            .Where(o => o.ReservationId == reservationId)
            .SelectMany(o => o.OrderItems)
            .Select(oi => oi.MenuItem!) 
            .Distinct() 
            .ToListAsync();
    }
    
    public static async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
    {
        await using var context = new RestaurantReservationDbContext();
        
        return await context.Reservations
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
    }
    
    public static async Task<List<Reservation>> GetAll()
    {
        await using var context = new RestaurantReservationDbContext();

        return await context.Reservations.ToListAsync();
    }
    
    public static async Task<Reservation?> GetById(int reservationId)
    {
        await using var context = new RestaurantReservationDbContext();

        return await context.Reservations
            .Where(r => r.ReservationId == reservationId).FirstOrDefaultAsync();
    }
}
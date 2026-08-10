using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public static class CustomerRepository
{
    public static async Task<int> Create(Customer customer)
    {
        await using var context = new RestaurantReservationDbContext();
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();

        return customer.CustomerId;
    }
    
    public static async Task<int?> Update(Customer updatedCustomer)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingCustomer = await context.Customers.FindAsync(updatedCustomer.CustomerId);

        if (existingCustomer == null) return null;
        existingCustomer.FirstName = updatedCustomer.FirstName;
        existingCustomer.LastName = updatedCustomer.LastName;
        existingCustomer.Email = updatedCustomer.Email;
        existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
        
        await context.SaveChangesAsync();
        return updatedCustomer.CustomerId;
    }
    
    public static async Task<int?> Delete(int id)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingCustomer = await context.Customers.FindAsync(id);

        if (existingCustomer == null) return null;
        context.Customers.Remove(existingCustomer);
        
        await context.SaveChangesAsync();
        return id;
    }
}
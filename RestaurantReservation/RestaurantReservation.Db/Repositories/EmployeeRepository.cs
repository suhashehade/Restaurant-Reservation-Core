using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public static class EmployeeRepository
{
    public static async Task<int> Create(Employee employee)
    {
        await using var context = new RestaurantReservationDbContext();
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();

        return employee.EmployeeId;
    }
    
    public static async Task<int?> Update(Employee updatedEmployee)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingEmployee = await context.Employees.FindAsync(updatedEmployee.EmployeeId);

        if (existingEmployee == null) return null;
        existingEmployee.FirstName = updatedEmployee.FirstName;
        existingEmployee.LastName = updatedEmployee.LastName;
        existingEmployee.Position = updatedEmployee.Position;
        
        await context.SaveChangesAsync();
        return updatedEmployee.EmployeeId;
    }
    
    public static async Task<int?> Delete(int id)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingEmployee = await context.Employees.FindAsync(id);

        if (existingEmployee == null) return null;
        context.Employees.Remove(existingEmployee);
        
        await context.SaveChangesAsync();
        return id;
    }
}
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using System.Linq;

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
    
    public static async Task<List<Employee>> ListManagers()
    {
        await using var context = new RestaurantReservationDbContext();
        return await context.Employees
            .Where(e => e.Position == "Manager")
            .ToListAsync();
    }
    
    public static async Task<decimal> CalculateAverageOrderAmount(int employeeId)
    {
        await using var context = new RestaurantReservationDbContext();

      
        var averageAmount = await context.Orders
            .Where(o => o.EmployeeId == employeeId)
            .AverageAsync(o => (decimal?)o.TotalAmount);
        
        return averageAmount ?? 0m; 
    }

}
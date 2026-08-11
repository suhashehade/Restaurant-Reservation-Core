using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeDetailsRepository
{
    public static async Task<List<EmployeeDetails>> View_EmployeeDetails()
    {
        await using var context = new RestaurantReservationDbContext();

        var employees = await context.EmployeeDetails
            .ToListAsync();

        return employees;
    }
}
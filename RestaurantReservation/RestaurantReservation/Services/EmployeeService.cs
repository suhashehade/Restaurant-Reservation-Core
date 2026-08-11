using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class EmployeeService
{
    public static async Task<List<Employee>> ListAllManagers()
    {
        return await EmployeeRepository.ListManagers();
    }
    
    public static async Task<decimal> CalculateAverageOrderAmount(int employeeId)
    {
        return await EmployeeRepository.CalculateAverageOrderAmount(employeeId);
    }
    
    public static async Task<List<EmployeeDetails>> ListEmployeesDetails()
    {
        return await EmployeeDetailsRepository.View_EmployeeDetails();
    }
    
}
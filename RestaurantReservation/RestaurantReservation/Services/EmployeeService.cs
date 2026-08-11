using System.Text.Json;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class EmployeeService
{
    public static async Task ListAllManagers(JsonSerializerOptions options)
    {
        var managers = await EmployeeRepository.ListManagers();
        foreach (var manager in managers)
        {
            Console.WriteLine(JsonSerializer.Serialize(manager, options));
        }
    }
    
    public static async Task CalculateAverageOrderAmount(int employeeId, JsonSerializerOptions options)
    {
        var average = await EmployeeRepository.CalculateAverageOrderAmount(employeeId);
        Console.WriteLine(average);
    }
    
    public static async Task ListEmployeesDetails(JsonSerializerOptions options)
    {
        var employeeDetailsList = await EmployeeDetailsRepository.View_EmployeeDetails();
        foreach (var employee in employeeDetailsList)
        {
            Console.WriteLine(JsonSerializer.Serialize(employee, options));
        }
    }
    
}
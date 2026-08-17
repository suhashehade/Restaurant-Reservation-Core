using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
var api = app.MapGroup("/api");
var reservationApi = api.MapGroup("/reservations");
var employeeApi = api.MapGroup("/employees");

reservationApi.MapGet("/", async () => await ReservationRepository.GetAll());

reservationApi.MapGet("/{id:int}", async (int id) =>
{
    var reservation = await ReservationRepository.GetById(id);
    return reservation == null ? Results.NotFound() : Results.Ok(reservation);
});

reservationApi.MapPost("/", async (Reservation reservation) =>
{
    var res = await ReservationRepository.Create(reservation);
    return Results.Ok(res);
});

reservationApi.MapPut("/{id:int}", async (int id, Reservation reservation) =>
{
    var res = await ReservationRepository.Update(id, reservation);
    return Results.Ok(res);
});

reservationApi.MapGet("/customer/{customerId:int}", async (int customerId) =>
{
    var res = await ReservationRepository.GetReservationsByCustomer(customerId);
    return Results.Ok(res);
});

reservationApi.MapGet("/{reservationId:int}/orders", async (int reservationId) =>
{
    var res = await ReservationRepository.ListOrdersAndMenuItems(reservationId);
    return Results.Ok(res);
});

reservationApi.MapGet("/{reservationId:int}/menuItems", async (int reservationId) =>
{
    var res = await ReservationRepository.ListOrderedAndMenuItems(reservationId);
    return Results.Ok(res);
});

employeeApi.MapGet("/managers", async () =>
{
    var managers = await EmployeeRepository.ListManagers();
    return Results.Ok(managers);
});

employeeApi.MapGet("/{employeeId:int}", async (int employeeId) =>
{
    var res = await EmployeeRepository.CalculateAverageOrderAmount(employeeId);
    return Results.Ok(res);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();


using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
var api = app.MapGroup("/api");
var reservationApi = api.MapGroup("/reservations");

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();


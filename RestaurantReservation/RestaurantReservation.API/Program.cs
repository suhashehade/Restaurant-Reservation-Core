using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using RestaurantReservation.API.Auth;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.API;

internal static class MainClass
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your JWT token."
            });

            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = []
            });
        });
        
        builder.Services.AddScoped<JwtTokenGenerator>();
        builder.Services.Configure<JwtConfig>(
            builder.Configuration.GetSection("JwtConfig")
        );

        var jwtConfig = builder.Configuration
                            .GetSection("JwtConfig")
                            .Get<JwtConfig>()
                        ?? throw new InvalidOperationException();
        
        var signingKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtConfig.Key)
        );
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                ValidateIssuer = true,
                ValidIssuer = jwtConfig.Issuer,

                ValidateAudience = true,
                ValidAudience = jwtConfig.Audience,

                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            });
        builder.Services.AddAuthorization();
        var app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapGet("/", () => "Hello World!");
        var api = app.MapGroup("/api");
        var reservationApi = api.MapGroup("/reservations");
        var employeeApi = api.MapGroup("/employees");

        reservationApi.MapGet("/", async () =>
        {
            
            var reservations = await ReservationRepository.GetAll();
            return Results.Ok(new {
                data = reservations,
                count = reservations.Count
            });
        }).RequireAuthorization();

        reservationApi.MapGet("/{id:int}", async (int id) =>
        {
            var reservation = await ReservationRepository.GetById(id);
            return reservation == null ? Results.NotFound() : Results.Ok(new {
                data = reservation
            });
        }).RequireAuthorization();

        reservationApi.MapPost("/", async (Reservation reservation) =>
        {
            var reservationId = await ReservationRepository.Create(reservation);
            return Results.Created($"/api/reservations/{reservationId}", new
            {
                id = reservationId
            });
        }).RequireAuthorization();

        reservationApi.MapPut("/{id:int}", async (int id, Reservation reservation) =>
        {
            var res = await ReservationRepository.Update(id, reservation);
            if (res == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(new
            {
                id
            });
        }).RequireAuthorization();
        
        reservationApi.MapDelete("/{id:int}", async (int id) =>
        {
           var reservationId = await ReservationRepository.Delete(id);
            if (reservationId == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(new
            {
                id = (int)reservationId
            });
        }).RequireAuthorization();

        reservationApi.MapGet("/customer/{customerId:int}", async (int customerId) =>
        {
            var reservationId = await ReservationRepository.GetReservationsByCustomer(customerId);
            return Results.Ok(new
            {
                id = reservationId
            });
        }).RequireAuthorization();

        reservationApi.MapGet("/{reservationId:int}/orders", async (int reservationId) =>
        {
            var ordersAndMenuItems = await ReservationRepository.ListOrdersAndMenuItems(reservationId);
            return Results.Ok(new {
               data = ordersAndMenuItems,
               count = ordersAndMenuItems.Count
            });
        }).RequireAuthorization();

        reservationApi.MapGet("/{reservationId:int}/menu-items", async (int reservationId) =>
        {
            var menuItems = await ReservationRepository.ListOrderedAndMenuItems(reservationId);
            return Results.Ok(new {
                data = menuItems,
                count = menuItems.Count
            });
        }).RequireAuthorization();

        employeeApi.MapGet("/managers", async () =>
        {
            var managers = await EmployeeRepository.ListManagers();
            return Results.Ok(new {
                data = managers,
                count = managers.Count
            });
        }).RequireAuthorization();

        employeeApi.MapGet("/{employeeId:int}/average-order-amount", async (int employeeId) =>
        {
            var res = await EmployeeRepository.CalculateAverageOrderAmount(employeeId);
            return Results.Ok(new {
                average = res
            });
        }).RequireAuthorization();
        
        app.MapPost("/login", (LoginRequest request, JwtTokenGenerator tokenGenerator) =>
        {
            if (request.Username == "" || request.Password == "")
            {
                return Results.BadRequest(new {
                    error = "username and password shouldn't be empty"
                });
            }
            
            if (request.Password.Length < 6)
            {
                return Results.BadRequest(new
                {
                    error = "Password should be at least 6 characters"
                });
            }
            
            if (!request.Username.Equals("suha", StringComparison.CurrentCultureIgnoreCase) || !request.Password.Equals("123456", StringComparison.CurrentCultureIgnoreCase))
            {
                return Results.Unauthorized();
            }

            var token = tokenGenerator.GenerateToken(
                request.Username,
                request.Password
            );

            return Results.Ok(new
            {
                token
            });
        });

        app.Run();
    }
}

public record LoginRequest(string Username, string Password);
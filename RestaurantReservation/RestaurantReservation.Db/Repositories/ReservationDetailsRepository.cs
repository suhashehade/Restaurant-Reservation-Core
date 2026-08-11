using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationDetailsRepository
{
    public static async Task<List<ReservationDetails>> View_ReservationDetails()
    {
        await using var context = new RestaurantReservationDbContext();

        var reservations = await context.ReservationDetails
            .ToListAsync();

        return reservations;
    }
}
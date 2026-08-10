using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public static class TableRepository
{
    public static async Task<int> Create(Table table)
    {
        await using var context = new RestaurantReservationDbContext();
        await context.Tables.AddAsync(table);
        await context.SaveChangesAsync();

        return table.TableId;
    }
    
    public static async Task<int?> Update(Table updatedTable)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingTable = await context.Tables.FindAsync(updatedTable.TableId);

        if (existingTable == null) return null;
        existingTable.Capacity = updatedTable.Capacity;
        
        await context.SaveChangesAsync();
        return updatedTable.TableId;
    }
    
    public static async Task<int?> Delete(int id)
    {
        await using var context = new RestaurantReservationDbContext();
        var existingTable = await context.Tables.FindAsync(id);

        if (existingTable == null) return null;
        context.Tables.Remove(existingTable);
        
        await context.SaveChangesAsync();
        return id;
    }
}
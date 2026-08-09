namespace RestaurantReservation.Db;
using Microsoft.EntityFrameworkCore;
public class RestaurantReservationDbContext: DbContext
{
  public RestaurantReservationDbContext()
  {
    
  }
  
  public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options)
    : base(options)
  {
  }
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer("Server=.;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;");
    }
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}

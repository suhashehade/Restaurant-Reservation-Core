using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db;
using Microsoft.EntityFrameworkCore;
public class RestaurantReservationDbContext: DbContext
{
  public RestaurantReservationDbContext() { }
  
  public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options)
    : base(options) { }
  
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }
  
  
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
    
    modelBuilder.Entity<Employee>()
      .HasOne<Restaurant>(e => e.Restaurant)
      .WithMany(r => r.Employees)
      .HasForeignKey(r => r.RestaurantId)
      .OnDelete(DeleteBehavior.Cascade);
    
    modelBuilder.Entity<Employee>()
      .HasMany<Order>(e => e.Orders)
      .WithOne(o => o.Employee)
      .HasForeignKey(o => o.EmployeeId)
      .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<MenuItem>()
      .HasOne<Restaurant>(m => m.Restaurant)
      .WithMany(r => r.MenuItems)
      .HasForeignKey(m => m.RestaurantId)
      .OnDelete(DeleteBehavior.Cascade);
    
    modelBuilder.Entity<Reservation>()
      .HasOne<Restaurant>(r => r.Restaurant)
      .WithMany(r => r.Reservations)
      .HasForeignKey(r => r.RestaurantId)
      .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<Reservation>()
      .HasOne<Table>(r => r.Table)
      .WithMany(r => r.Reservations)
      .HasForeignKey(r => r.TableId)
      .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<Reservation>()
      .HasOne<Customer>(r => r.Customer)
      .WithMany(c => c.Reservations)
      .HasForeignKey(r => r.CustomerId)
      .OnDelete(DeleteBehavior.Cascade);
    
    modelBuilder.Entity<Reservation>()
      .HasMany<Order>(r => r.Orders)
      .WithOne(o => o.Reservation)
      .HasForeignKey(o => o.ReservationId)
      .OnDelete(DeleteBehavior.Cascade);
    
    modelBuilder.Entity<Order>()
      .HasMany<OrderItem>(o => o.OrderItems)
      .WithOne(o => o.Order)
      .HasForeignKey(o => o.OrderId)
      .OnDelete(DeleteBehavior.Cascade);
    
    modelBuilder.Entity<OrderItem>()
      .HasOne<MenuItem>(o => o.MenuItem)
      .WithMany(m => m.OrderItems)
      .HasForeignKey(o => o.ItemId)
      .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<Table>()
      .HasOne<Restaurant>(t => t.Restaurant)
      .WithMany(r => r.Tables)
      .HasForeignKey(t => t.RestaurantId)
      .OnDelete(DeleteBehavior.Cascade);
    
  }
}

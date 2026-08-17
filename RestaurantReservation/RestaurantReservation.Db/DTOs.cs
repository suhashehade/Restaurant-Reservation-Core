namespace RestaurantReservation.Db;

public class OrderWithMenuItemsDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderMenuItemDto> MenuItems { get; set; } = new();
}

public class OrderMenuItemDto
{
    public int ItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
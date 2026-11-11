namespace BTH5_ReportingService.Models;

public class ProductReport
{
    public int Id { get; set; }
    public string ProductName { get; set; } = "";
    public int StockQuantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal SellingPrice { get; set; }
}
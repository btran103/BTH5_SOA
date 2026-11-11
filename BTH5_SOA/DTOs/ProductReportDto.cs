namespace BTH5_ReportingService.DTOs;

public class ProductReportDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public int StockQuantity { get; set; }
    public int SoldQuantity { get; set; }
    public decimal Revenue { get; set; }
    public decimal Cost { get; set; }
    public decimal Profit { get; set; }
}
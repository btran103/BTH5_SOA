namespace BTH5_ReportingService.DTOs;

public class OrderReportDto
{
    public string OrderCode { get; set; } = "";
    public DateTime OrderDate { get; set; }
    public string ProductName { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Revenue { get; set; }
    public decimal Cost { get; set; }
    public decimal Profit { get; set; }
    public string Status { get; set; } = "";
}
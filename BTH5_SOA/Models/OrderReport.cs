namespace BTH5_ReportingService.Models;

public class OrderReport
{
    public int Id { get; set; }
    public string OrderCode { get; set; } = "";
    public DateTime OrderDate { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal UnitCost { get; set; }
    public decimal OtherCost { get; set; }
    public string Status { get; set; } = "Completed";
}
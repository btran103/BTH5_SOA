namespace BTH5_ReportingService.DTOs;

public class SummaryReportDto
{
    public int TotalInventory { get; set; }
    public int TotalSold { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal TotalCost { get; set; }
    public decimal TotalProfit { get; set; }
}
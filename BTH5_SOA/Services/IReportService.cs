using BTH5_ReportingService.DTOs;

namespace BTH5_ReportingService.Services;

public interface IReportService
{
    Task<SummaryReportDto> GetSummary();
    Task<List<ProductReportDto>> GetProductReports();
    Task<List<OrderReportDto>> GetOrderReports();
}
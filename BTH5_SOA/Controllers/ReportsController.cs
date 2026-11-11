using Microsoft.AspNetCore.Mvc;
using BTH5_ReportingService.Services;

namespace BTH5_ReportingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        return Ok(await _reportService.GetSummary());
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _reportService.GetProductReports());
    }

    [HttpGet("orders")]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _reportService.GetOrderReports());
    }
}
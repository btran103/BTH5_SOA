using Microsoft.EntityFrameworkCore;
using BTH5_ReportingService.Data;
using BTH5_ReportingService.DTOs;

namespace BTH5_ReportingService.Services;

public class ReportService : IReportService
{
    private readonly ReportDbContext _context;

    public ReportService(ReportDbContext context)
    {
        _context = context;
    }

    public async Task<SummaryReportDto> GetSummary()
    {
        var products = await _context.Products.ToListAsync();

        var orders = await _context.Orders
            .Where(o => o.Status == "Completed")
            .ToListAsync();

        decimal revenue = orders.Sum(o => o.Quantity * o.UnitPrice);

        decimal cost = orders.Sum(o =>
            o.Quantity * o.UnitCost + o.OtherCost);

        return new SummaryReportDto
        {
            TotalInventory = products.Sum(p => p.StockQuantity),
            TotalSold = orders.Sum(o => o.Quantity),
            TotalRevenue = revenue,
            TotalCost = cost,
            TotalProfit = revenue - cost
        };
    }

    public async Task<List<ProductReportDto>> GetProductReports()
    {
        var products = await _context.Products.ToListAsync();

        var orders = await _context.Orders
            .Where(o => o.Status == "Completed")
            .ToListAsync();

        return products.Select(p =>
        {
            var productOrders = orders
                .Where(o => o.ProductId == p.Id)
                .ToList();

            decimal revenue = productOrders.Sum(o =>
                o.Quantity * o.UnitPrice);

            decimal cost = productOrders.Sum(o =>
                o.Quantity * o.UnitCost + o.OtherCost);

            return new ProductReportDto
            {
                ProductId = p.Id,
                ProductName = p.ProductName,
                StockQuantity = p.StockQuantity,
                SoldQuantity = productOrders.Sum(o => o.Quantity),
                Revenue = revenue,
                Cost = cost,
                Profit = revenue - cost
            };
        }).ToList();
    }

    public async Task<List<OrderReportDto>> GetOrderReports()
    {
        var orders = await _context.Orders.ToListAsync();

        return orders.Select(o =>
        {
            decimal revenue = o.Quantity * o.UnitPrice;
            decimal cost = o.Quantity * o.UnitCost + o.OtherCost;

            return new OrderReportDto
            {
                OrderCode = o.OrderCode,
                OrderDate = o.OrderDate,
                ProductName = o.ProductName,
                Quantity = o.Quantity,
                Revenue = revenue,
                Cost = cost,
                Profit = revenue - cost,
                Status = o.Status
            };
        }).ToList();
    }
}
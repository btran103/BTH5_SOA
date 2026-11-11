using Microsoft.EntityFrameworkCore;
using BTH5_ReportingService.Data;
using BTH5_ReportingService.Models;
using BTH5_ReportingService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReportDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ReportDatabase")));

builder.Services.AddScoped<IReportService, ReportService>();

var app = builder.Build();

// Tạo database và dữ liệu mẫu
try
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ReportDbContext>();

    db.Database.EnsureCreated();

    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new ProductReport
            {
                ProductName = "Laptop Dell",
                StockQuantity = 20,
                UnitCost = 12000000,
                SellingPrice = 15000000
            },
            new ProductReport
            {
                ProductName = "Chuột Logitech",
                StockQuantity = 50,
                UnitCost = 200000,
                SellingPrice = 350000
            },
            new ProductReport
            {
                ProductName = "Bàn phím cơ",
                StockQuantity = 30,
                UnitCost = 500000,
                SellingPrice = 750000
            }
        );

        await db.SaveChangesAsync();
    }

    if (!db.Orders.Any())
    {
        db.Orders.AddRange(
            new OrderReport
            {
                OrderCode = "DH001",
                OrderDate = DateTime.Now.AddDays(-2),
                ProductId = 1,
                ProductName = "Laptop Dell",
                Quantity = 2,
                UnitPrice = 15000000,
                UnitCost = 12000000,
                OtherCost = 500000,
                Status = "Completed"
            },
            new OrderReport
            {
                OrderCode = "DH002",
                OrderDate = DateTime.Now.AddDays(-1),
                ProductId = 2,
                ProductName = "Chuột Logitech",
                Quantity = 5,
                UnitPrice = 350000,
                UnitCost = 200000,
                OtherCost = 50000,
                Status = "Completed"
            },
            new OrderReport
            {
                OrderCode = "DH003",
                OrderDate = DateTime.Now,
                ProductId = 3,
                ProductName = "Bàn phím cơ",
                Quantity = 3,
                UnitPrice = 750000,
                UnitCost = 500000,
                OtherCost = 30000,
                Status = "Pending"
            }
        );

        await db.SaveChangesAsync();
    }
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra ConnectionString trong appsettings.json và chắc chắn rằng dịch vụ SQL Server đang chạy.");
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthorization();
app.MapControllers();

app.Run();
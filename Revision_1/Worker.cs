using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Revision_1.Data;
using Revision_1.Entities;
using Revision_1.UnitOfWork.Interfaces;

namespace Revision_1;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Database worker started!");

        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope()) 
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var newProduct = new Product("Test Product", 200 , "Test Description");
                await unitOfWork.Products.AddAsync(newProduct);
                await unitOfWork.CompleteAsync();

                var products = await unitOfWork.Products.GetAllAsync();
                _logger.LogInformation($"Products count: {products.Count()}");
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}
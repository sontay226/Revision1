using Revision_1.UnitOfWork.Interfaces;
using Revision_1.Entities;
namespace Revision_1;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public Worker(ILogger<Worker> logger , IUnitOfWork unitOfWork) {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        Console.WriteLine("Database worker started!");
        while (!stoppingToken.IsCancellationRequested) {
            var newProduct = new Product("1", "test", "test des ", 200);
            await _unitOfWork.Products.addAsync(newProduct);
            await _unitOfWork.CompleteAsync();
            var products = await _unitOfWork.Products.getAllAsync();
            _logger.LogInformation($"Products count: {products.Count()}");
            await Task.Delay(5000, stoppingToken);
        }
    }
}
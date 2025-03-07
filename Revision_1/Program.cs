using Revision_1;
using Revision_1.Data;
using Revision_1.Repositories.Implementations;
using Revision_1.Repositories.Interfaces;
using Revision_1.UnitOfWork.Implementations;
using Revision_1.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
var builder = Host.CreateApplicationBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var host = builder.Build();
host.Run();
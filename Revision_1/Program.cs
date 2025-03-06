using Revision_1;
using Revision_1.Repositories.Implementations;
using Revision_1.Repositories.Interfaces;
using Revision_1.UnitOfWork.Implementations;
using Revision_1.UnitOfWork.Interfaces;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var host = builder.Build();
host.Run();
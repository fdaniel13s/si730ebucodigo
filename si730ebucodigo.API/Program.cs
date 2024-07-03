using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebucodigo.API.Inventory.Application.Internal.CommandServices;
using si730ebucodigo.API.Inventory.Application.Internal.QueryServices;
using si730ebucodigo.API.Inventory.Domain.Repositories;
using si730ebucodigo.API.Inventory.Domain.Services;
using si730ebucodigo.API.Inventory.Infrastructure.Persistence.EFC.Repositories;
using si730ebucodigo.API.Inventory.Interfaces.ACL;
using si730ebucodigo.API.Inventory.Interfaces.ACL.Services;
using si730ebucodigo.API.Inventory.Interfaces.REST;
using si730ebucodigo.API.Maintenance.Application.Internal.CommandServices;
using si730ebucodigo.API.Maintenance.Application.Internal.OutboundServices.ACL;
using si730ebucodigo.API.Maintenance.Application.Internal.QueryServices;
using si730ebucodigo.API.Maintenance.Domain.Repositories;
using si730ebucodigo.API.Maintenance.Domain.Services;
using si730ebucodigo.API.Maintenance.Infrastructure.Persistence.EFC.Repositories;
using si730ebucodigo.API.Shared.Domain.Repositories;
using si730ebucodigo.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebucodigo.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using si730ebucodigo.API.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ISA API", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
        if (builder.Environment.IsDevelopment())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        else if (builder.Environment.IsProduction())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();

builder.Services.AddScoped<IMaintenanceActivityCommandService, MaintenanceActivityCommandService>();
builder.Services.AddScoped<IMaintenanceActivityQueryService, MaintenanceActivityQueryService>();
builder.Services.AddScoped<IMaintenanceActivityRepository, MaintenanceActivityRepository>();

builder.Services.AddScoped<IProductsContextFacade, ProductsContextFacade>();

builder.Services.AddScoped<ExternalProductService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#region My Changes: Including using directives

using BackendMastery.Architecture.DependencyInjection.Infrastructure;
using BackendMastery.Architecture.DependencyInjection.Repositories;
using BackendMastery.Architecture.DependencyInjection.Repositories.Interfaces;
using BackendMastery.Architecture.DependencyInjection.Services;
using BackendMastery.Architecture.DependencyInjection.Services.Interfaces;

#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region My Changes: Wiring Dependencies

/// Intuition:
/// - Object graph is built at application startup
/// - Lifetime choices matter
///
/// Rule of thumb:
/// - Stateless services → Scoped
/// - Infrastructure → Singleton (if safe)
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, InMemoryOrderRepository>();
builder.Services.AddSingleton<ISystemClock, SystemClock>();

#endregion

var app = builder.Build();

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

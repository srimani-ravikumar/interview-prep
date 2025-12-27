using BackendMastery.Architecture.StandardAPI.Api.Filters;
using BackendMastery.Architecture.StandardAPI.Application.Interfaces.Repositories;
using BackendMastery.Architecture.StandardAPI.Application.Interfaces.Services;
using BackendMastery.Architecture.StandardAPI.Application.Services;
using BackendMastery.Architecture.StandardAPI.Application.Validators;
using BackendMastery.Architecture.StandardAPI.Infrastructure.Persistence;
using BackendMastery.Architecture.StandardAPI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Infrastructure
// --------------------

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

// --------------------
// Application
// --------------------

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<CreateOrderValidator>();

// --------------------
// API
// --------------------

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --------------------
// HTTP Pipeline
// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
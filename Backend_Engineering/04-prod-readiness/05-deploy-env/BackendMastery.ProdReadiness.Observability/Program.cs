using BackendMastery.ProdReadiness.Observability.Infrastructure;
using BackendMastery.ProdReadiness.Observability.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Structured logging (console for demo, extensible later)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<UnreliableInventoryClient>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Correlation must be first
app.UseMiddleware<CorrelationIdMiddleware>();


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

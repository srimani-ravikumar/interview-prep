using BackendMastery.ProdReadiness.Bulkheads.Configuration;
using BackendMastery.ProdReadiness.Bulkheads.Infrastructure;
using BackendMastery.ProdReadiness.Bulkheads.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Separate bulkheads per feature
builder.Services.AddSingleton(
    new Bulkhead(maxConcurrency: 2)); // Reports

builder.Services.AddSingleton(
    new Bulkhead(maxConcurrency: 5)); // Analytics

builder.Services.AddScoped<IReportsService, ReportsService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

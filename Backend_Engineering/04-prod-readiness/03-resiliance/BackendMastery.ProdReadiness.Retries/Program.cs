using BackendMastery.ProdReadiness.Retries.Configuration;
using BackendMastery.ProdReadiness.Retries.Infrastructure;
using BackendMastery.ProdReadiness.Retries.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var retryOptions = builder.Configuration
    .GetSection("Retries")
    .Get<RetryOptions>();

builder.Services.AddSingleton(retryOptions!);
builder.Services.AddSingleton<UnstableReportClient>();
builder.Services.AddScoped<IReportService, ReportService>();

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

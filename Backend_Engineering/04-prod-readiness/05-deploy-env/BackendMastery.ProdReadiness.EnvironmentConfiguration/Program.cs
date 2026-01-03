using BackendMastery.ApiProduction.EnvironmentConfiguration.Configuration;
using BackendMastery.ApiProduction.EnvironmentConfiguration.Infrastructure;
using BackendMastery.ApiProduction.EnvironmentConfiguration.Middleware;
using BackendMastery.ApiProduction.EnvironmentConfiguration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Environment resolution
var resolver = new EnvironmentResolver();
var environment = resolver.Resolve();

// Configuration loading order matters
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{environment}.json", optional: true)
    .AddEnvironmentVariables();

// Bind strongly-typed options
builder.Services.Configure<EnvironmentOptions>(
    builder.Configuration.GetSection("Environment"));

builder.Services.AddSingleton<EnvironmentResolver>();
builder.Services.AddSingleton<EnvironmentBehaviorService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enforce environment safety at runtime
app.UseMiddleware<EnvironmentGuardMiddleware>();


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

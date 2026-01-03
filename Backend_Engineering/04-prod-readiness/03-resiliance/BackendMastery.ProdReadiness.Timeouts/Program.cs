using BackendMastery.ProdReadiness.Timeouts.Configuration;
using BackendMastery.ProdReadiness.Timeouts.Infrastructure;
using BackendMastery.ProdReadiness.Timeouts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Bind timeout budgets explicitly
builder.Services.Configure<TimeoutOptions>(
    builder.Configuration.GetSection("Timeouts"));

builder.Services.AddSingleton(sp =>
{
    var options = sp.GetRequiredService<
        Microsoft.Extensions.Options.IOptions<TimeoutOptions>>().Value;

    return new ExternalWeatherClient(options);
});

builder.Services.AddScoped<IWeatherService, WeatherService>();


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

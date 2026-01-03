using BackendMastery.ProdReadiness.CircuitBreakers.Configuration;
using BackendMastery.ProdReadiness.CircuitBreakers.Infrastructure;
using BackendMastery.ProdReadiness.CircuitBreakers.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var options = builder.Configuration
    .GetSection("CircuitBreaker")
    .Get<CircuitBreakerOptions>();

builder.Services.AddSingleton(new CircuitBreaker(
    options!.FailureThreshold,
    TimeSpan.FromSeconds(options.OpenStateDurationSeconds)));

builder.Services.AddSingleton<FlakyPaymentGateway>();
builder.Services.AddScoped<IPaymentService, PaymentService>();


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

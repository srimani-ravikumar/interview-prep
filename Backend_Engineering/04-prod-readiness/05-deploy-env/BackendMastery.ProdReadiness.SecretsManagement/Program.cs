using BackendMastery.ProdReadiness.SecretsManagement.Configuration;
using BackendMastery.ProdReadiness.SecretsManagement.Infrastructure;
using BackendMastery.ProdReadiness.SecretsManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables();

builder.Services.Configure<ExternalServiceOptions>(
    builder.Configuration.GetSection("ExternalService"));

builder.Services.AddSingleton<SecretProvider>();
builder.Services.AddSingleton<ExternalServiceClient>();


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

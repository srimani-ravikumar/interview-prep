using BackendMastery.ECommerce.API.Middleware;
using BackendMastery.ECommerce.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuration-driven infrastructure selection
var provider = builder.Configuration["Persistence:Provider"];
var connectionString =
    builder.Configuration.GetConnectionString("ECommerceDb");

if (provider == "EfCore")
{
    builder.Services.AddEfCoreInfrastructure(connectionString!);
}
else
{
    builder.Services.AddInMemoryInfrastructure();
}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global exception handling
app.UseMiddleware<ExceptionHandlingMiddleware>();

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


// THIS IS THE KEY LINE
public partial class Program { }
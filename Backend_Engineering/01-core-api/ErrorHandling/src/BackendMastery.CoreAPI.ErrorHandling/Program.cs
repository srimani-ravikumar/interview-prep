#region MyChanges: Including using directives

using BackendMastery.CoreAPI.ErrorHandling.Middleware;

#endregion


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

#region MyChanges: Adding custom global exceptional handling middleware

app.UseMiddleware<GlobalExceptionMiddleware>();

#endregion

app.Run();

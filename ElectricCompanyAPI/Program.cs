using ElectricCompanyApi.Infrastructure;
using ElectricCompanyAPI;
using ElectricCompanyAPI.Domain;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IHistoricDataRepository, HistoricDataRepository>();
builder.Services.AddScoped< HistoricDataService>();

var app = builder.Build();

// Enable Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Electric Company API v1");
    options.RoutePrefix = "swagger"; // Access at /swagger
});

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

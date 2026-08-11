using Microsoft.EntityFrameworkCore;
using PivotTable_EFCore.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Get the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("SalesDb");

// Register the DbContext with the SQL Server provider
builder.Services.AddDbContext<SalesDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Enable CORS to allow requests from React client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");  // Apply CORS policy
app.MapControllers();

app.Run();

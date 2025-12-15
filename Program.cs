using Microsoft.EntityFrameworkCore;
using SelfLearning.Configurations;
using SelfLearning.Data;
using SelfLearning.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add application services (Database, Repositories, Services, AutoMapper)
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add exception middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

// Ensure database is created and tables are created
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    try
    {
        logger.LogInformation("Ensuring database is created...");
        var created = db.Database.EnsureCreated();
        if (created)
        {
            logger.LogInformation("Database and tables created successfully.");
        }
        else
        {
            logger.LogInformation("Database already exists.");
        }
        
        // Verify table exists
        var canConnect = db.Database.CanConnect();
        logger.LogInformation($"Can connect to database: {canConnect}");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while creating the database.");
        throw; // Re-throw to see the error
    }
}

app.Run();

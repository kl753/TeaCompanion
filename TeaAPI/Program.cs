using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; // Add this using directive for Npgsql
using TeaAPI.Data; // Assuming the DbContext is in the Data namespace
using TeaAPI.Mappers; // Assuming the AutoMapper profiles are in the Mappers namespace
using TeaAPI.Services; // Assuming the service layer is in the Services namespace
using TeaAPI.Repositories; // Assuming the repository layer is in the Repositories namespace

// Existing code remains unchanged
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configure PostgreSQL connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)); // Use Npgsql for PostgreSQL

//Register Repositories and services
builder.Services.AddScoped<ITeaRepository, TeaRepository>();
builder.Services.AddScoped<ITeaService, TeaService>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

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

    //Apply migrations and seed the database in development mode
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate(); // Apply migrations
        //DbInitializer.Seed(dbContext); // Seed the database with initial data
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
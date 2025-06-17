using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using TeaAPI.Mappers; // Add this using directive for Npgsql

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configure PostgreSQL database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)); // Use Npgsql for PostgreSQL

//Register the repository and service
builder.Services.AddScoped<ITeaRepository, TeaRepository>();
builder.Services.AddScoped<ITeaService, TeaService>();

//Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles)); // Assuming your mapping profiles are in the same assembly

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

    //Apply migrations and seed data on startup in development mode
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate(); // Apply migrations
        // Seed data if necessary
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

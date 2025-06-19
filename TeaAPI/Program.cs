using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; // Add this using directive for Npgsql
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Set to true in production
    options.SaveToken = true; // Save the token in the authentication properties
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"]
        ValidateLifetime = true, // Validate the token's expiration time
        ClockSkew = TimeSpan.Zero // Set clock skew to zero to avoid issues with token expiration
    };
});

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

app.UseAuthentication(); // Enable authentication middleware

app.UseAuthorization();

app.MapControllers();

app.Run();
using HotelListing.API.Configurations;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Models;
using HotelListing.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 9
builder.Services.AddIdentityCore<ApiUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<HotelListingDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => 
    {
        b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod(); 
    });
});

// 3
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
});

// 4
builder.Services.AddDbContext<HotelListingDbContext>(options =>
{
    options.UseSqlServer("name=HotelListingDBConnectionString");
});

// 5
builder.Services.AddAutoMapper(typeof(MapperConfig));

// 6
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// 7
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();

// 8
builder.Services.AddScoped<IHotelsRepository, HotelsRepository>();

// 10
builder.Services.AddScoped<IAuthManager, AuthManager>();

// 11
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 2
app.UseCors("AllowAll");

// 12
app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();

app.Run();

// Seq container
// docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
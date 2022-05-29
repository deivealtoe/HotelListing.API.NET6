using HotelListing.API.Configurations;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

// Seq container
// docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
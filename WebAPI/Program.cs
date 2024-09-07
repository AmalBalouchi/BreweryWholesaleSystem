using Application.Services;
using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// The use cases are not automatically registered in the DI container
// Register the use case services here
builder.Services.AddScoped<AddBeerByBrewer>();
builder.Services.AddScoped<DeleteBeerByBrewer>();
builder.Services.AddScoped<GetBeersByBrewer>();

// Add your service as a scoped dependency
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IBeerRepository, BeerRepository>();

builder.Services.AddScoped<IBrewerRepository, BrewerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BreweryWholesaleSystem API", Version = "v1" });

    //WebAPI contains controllers seperately (Clean Architecture principles)
    //need to include controllers from WebAPI project into Swagger
    c.SwaggerDoc("webapi", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
});

// Configure the DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add the repositories as a scoped dependency
builder.Services.AddScoped<IBrewerRepository, BrewerRepository>(); // Register the BrewerRepository
builder.Services.AddScoped<IBeerRepository, BeerRepository>(); // Register the BeerRepository

// Add the services as a scoped dependency
builder.Services.AddScoped<BrewerService>(); // Register the BrewerService
builder.Services.AddScoped<BeerService>(); // Register the BeerService

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BreweryWholesaleSystem API V1");

        c.SwaggerEndpoint("/swagger/webapi/swagger.json", "WebAPI V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
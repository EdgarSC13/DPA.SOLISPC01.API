using DPA.SOLISPC01.DOMAIN.Core.Interfaces;
using DPA.SOLISPC01.DOMAIN.Infrastructure.Data;
using DPA.SOLISPC01.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
var connectionString = config.GetConnectionString("DevConnection");
builder.Services.AddDbContext<SistemaReservasCanchasContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICanchasRepository, CanchasRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

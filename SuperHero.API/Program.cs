using Microsoft.EntityFrameworkCore;
using SuperHero.API;
using SuperHero.Infrastructure;
using System.Buffers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AutoMapper();
builder.Services.AddDbContext<AppDbContext>(options =>
                                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.DependencyInjectionAutoFac();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
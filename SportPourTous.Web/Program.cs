using Microsoft.EntityFrameworkCore;
using SportPourTous.Infrastructure.Database;
using Microsoft.AspNetCore.OpenApi;
using SportPourTous.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Registering necessary services for the program
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("reservations"));
builder.Services.AddControllers(); 

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

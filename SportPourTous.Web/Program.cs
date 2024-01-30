using Microsoft.EntityFrameworkCore;
using SportPourTous.Application.Services;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Database;
using SportPourTous.Infrastructure.Repositories;
using SportPourTous.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>(); 

builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("reservations"));
builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SportPourTous.Application.Interfaces;
using SportPourTous.Application.Services;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Database;
using SportPourTous.Infrastructure.Repositories;
using SportPourTous.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IGetReservationQueryHandler, GetReservationQueryHandler>();
builder.Services.AddScoped<IDeleteReservationCommandHandler, DeleteReservationCommandHandler>();



builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();

builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("reservations"));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

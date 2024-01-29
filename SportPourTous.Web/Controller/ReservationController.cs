using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportPourTous.Domain.Entities;
using SportPourTous.Infrastructure.Database;

namespace SportPourTous.Web.Controllers 
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public ReservationsController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _db.Reservations.ToListAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(Guid id)
        {
            var reservation = await _db.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            await _db.Reservations.AddAsync(reservation);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(Guid id, Reservation updatedReservation)
        {
            var reservation = await _db.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            reservation.BeginningHour = updatedReservation.BeginningHour;
            reservation.EndingHour = updatedReservation.EndingHour;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            var reservation = await _db.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            _db.Reservations.Remove(reservation);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}

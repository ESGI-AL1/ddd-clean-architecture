using Microsoft.AspNetCore.Mvc;
using SportPourTous.Application.Services;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Web.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservationsAsync();
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById([FromRoute] ReservationId id)
        {
            try
            {
                var reservation = await _reservationService.GetReservationByIdAsync(id);
                if (reservation == null)
                {
                    return NotFound(); // Return 404 if the reservation is not found.
                }
                return Ok(reservation);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            try
            {
                await _reservationService.CreateReservationAsync(reservation);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation([FromRoute] ReservationId id, [FromBody] Reservation reservationDto)
        {
            try
            {
                // You can implement the logic for updating a reservation here, using the service.
                // For example: var updatedReservation = await _reservationService.UpdateReservationAsync(id, reservationDto);

                return Ok(); // Return a success response.
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] ReservationId id)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(id);
                return NoContent(); // Return a success response with no content.
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

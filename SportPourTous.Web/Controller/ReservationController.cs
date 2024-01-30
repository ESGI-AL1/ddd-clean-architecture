using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQRS.Queries;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Exceptions;
using SportPourTous.Web.DTO;


namespace SportPourTous.Web.Controllers 
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IGetReservationQueryHandler _getReservationQueryHandler;


        public ReservationsController(IReservationService reservationService, IGetReservationQueryHandler getReservationQueryHandler)
        {
            _reservationService = reservationService;
            _getReservationQueryHandler = getReservationQueryHandler;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservations();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(Guid id)
        {
            var query = new GetReservationQuery { Id = id };
            var reservation = await _getReservationQueryHandler.Handle(query);
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationIdResponseDto>> CreateReservation(Reservation reservation)
        {
            var reservationId = await _reservationService.CreateReservation(reservation);
            var reservationDto = new ReservationIdResponseDto { Id = reservationId };
            return CreatedAtAction(nameof(GetReservation), new { id = reservationId }, reservationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(Guid id, Reservation updatedReservation)
        {
            try
            {
                await _reservationService.UpdateReservation(id, updatedReservation);
                return NoContent();
            }
            catch(ReservationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            try
            {
                await _reservationService.DeleteReservation(id);
                return Ok();
            }
            catch(ReservationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}

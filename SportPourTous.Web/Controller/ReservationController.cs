using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;   
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
            try
            {
                var reservation = await _reservationService.GetReservation(id);
                return Ok(reservation);
            }
            catch(ReservationNotFoundException ex)
            {
                return NotFound(ex.Message);  
            }            
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

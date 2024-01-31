using AutoMapper;
using FluentValidation;
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
        private readonly IDeleteReservationCommandHandler _deleteReservationCommandHandler;
        private readonly IMapper _mapper;



        public ReservationsController(IReservationService reservationService, 
                                      IGetReservationQueryHandler getReservationQueryHandler,
                                      IDeleteReservationCommandHandler deleteReservationCommandHandler,
                                      IMapper mapper)
        {
            _reservationService = reservationService;
            _getReservationQueryHandler = getReservationQueryHandler;
            _deleteReservationCommandHandler = deleteReservationCommandHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _getReservationQueryHandler.HandleGetAllReservations();
            var reservationDtos = _mapper.Map<List<ReservationResponseDto>>(reservations);
            return Ok(reservationDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(Guid id)
        {
            var query = new GetReservationQuery { Id = id };
            var reservation = await _getReservationQueryHandler.HandleGetReservationById(query);
            var reservationDto = _mapper.Map<ReservationResponseDto>(reservation);
            return Ok(reservationDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            try
            {
                var reservationId = await _reservationService.CreateReservation(reservation);
                var reservationDto = new ReservationIdResponseDto { Id = reservationId };
                return CreatedAtAction(nameof(GetReservation), new { id = reservationId }, reservationDto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
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
                await _deleteReservationCommandHandler.Handle(id);
                return Ok();
            }
            catch(ReservationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}

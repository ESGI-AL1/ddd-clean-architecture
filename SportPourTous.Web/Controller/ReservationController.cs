using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQRS.Commands;
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
        private readonly ICreateReservationCommandHandler _createReservationCommandHandler;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, 
                                      IGetReservationQueryHandler getReservationQueryHandler,
                                      IDeleteReservationCommandHandler deleteReservationCommandHandler,
                                      ICreateReservationCommandHandler createReservationCommandHandler,
                                      IMapper mapper)
        {
            _reservationService = reservationService;
            _getReservationQueryHandler = getReservationQueryHandler;
            _deleteReservationCommandHandler = deleteReservationCommandHandler;
            _createReservationCommandHandler = createReservationCommandHandler;
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
        public async Task<IActionResult> CreateReservation(CreateReservationDto reservation)
        {
            try
            {
                var command = _mapper.Map<CreateReservationCommand>(reservation);
                var reservationId = await _createReservationCommandHandler.HandleCreateReservation(command);
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
                var command = new DeleteReservationCommand { Id = id };
                await _deleteReservationCommandHandler.Handle(command);
                return Ok();
            }
            catch(ReservationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

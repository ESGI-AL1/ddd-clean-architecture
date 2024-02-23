using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQS.Commands;
using SportPourTous.Domain.CQS.Queries;
using SportPourTous.Infrastructure.Exceptions;
using SportPourTous.Web.DTO;

namespace SportPourTous.Web.Controllers 
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationsController(
        IGetReservationQueryHandler getReservationQueryHandler,
        IDeleteReservationCommandHandler deleteReservationCommandHandler,
        ICreateReservationCommandHandler createReservationCommandHandler,
        IUpdateReservationCommandHandler updateReservationCommandHandler,
        IMapper mapper) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await getReservationQueryHandler.HandleGetAllReservations();
            var reservationDto = mapper.Map<List<ReservationResponseDto>>(reservations);
            return Ok(reservationDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(Guid id)
        {
            var query = new GetReservationQuery { Id = id };
            var reservation = await getReservationQueryHandler.HandleGetReservationById(query);
            var reservationDto = mapper.Map<ReservationResponseDto>(reservation);
            return Ok(reservationDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto reservation)
        {
            try
            {
                var command = mapper.Map<CreateReservationCommand>(reservation);
                var reservationId = await createReservationCommandHandler.HandleCreateReservation(command);
                var reservationDto = new ReservationIdResponseDto { Id = reservationId };
                return CreatedAtAction(nameof(GetReservation), new { id = reservationId }, reservationDto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(Guid id, UpdateReservationDto reservation)
        {
            try
            {
                var command = mapper.Map<UpdateReservationCommand>(reservation);
                var updatedReservation = await updateReservationCommandHandler.HandleUpdateReservation(id, command);
                var reservationDto = new ReservationIdResponseDto { Id = updatedReservation };
                return Ok(reservationDto);
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
                await deleteReservationCommandHandler.Handle(command);
                return Ok();
            }
            catch(ReservationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

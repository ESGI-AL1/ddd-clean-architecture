using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQRS.Queries;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Exceptions;

public class GetReservationQueryHandler : IGetReservationQueryHandler
{
    private readonly IReservationRepository _repository;

    public GetReservationQueryHandler(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Reservation> Handle(GetReservationQuery query)
    {
        return await _repository.GetReservation(query.Id)
               ?? throw new ReservationNotFoundException(query.Id);
    }
}

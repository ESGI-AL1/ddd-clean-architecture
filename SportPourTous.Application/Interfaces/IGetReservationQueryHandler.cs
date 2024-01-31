using SportPourTous.Domain.CQRS.Queries;
using SportPourTous.Domain.Entities;

namespace SportPourTous.Application.Interfaces
{
    public interface IGetReservationQueryHandler
    {
        Task<IEnumerable<Reservation>> HandleGetAllReservations();   
        Task<Reservation> HandleGetReservationById(GetReservationQuery handler);  
    }
}

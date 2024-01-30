using SportPourTous.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportPourTous.Domain.Interfaces
{
    public interface IReservation
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> GetReservation(Guid id);
        Task<Guid> CreateReservation(Reservation reservation);
        Task<Guid> UpdateReservation(Guid id, Reservation reservation);
        Task DeleteReservation(Guid id);
    }
}

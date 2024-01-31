using SportPourTous.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportPourTous.Domain.Interfaces
{
    public interface IReservationService
    {
        Task<Guid> CreateReservation(Reservation reservation);
        Task<Guid> UpdateReservation(Guid id, Reservation reservation);
    }
}

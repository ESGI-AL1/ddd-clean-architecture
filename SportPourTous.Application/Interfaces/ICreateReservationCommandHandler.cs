using SportPourTous.Domain.CQRS.Commands;
using SportPourTous.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportPourTous.Application.Interfaces
{
    public interface ICreateReservationCommandHandler
    {
        Task<Guid> HandleCreateReservation(CreateReservationCommand reservation);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportPourTous.Domain.CQS.Commands;

namespace SportPourTous.Application.Interfaces
{
    public interface IDeleteReservationCommandHandler
    {
        Task Handle(DeleteReservationCommand id);
    }
}

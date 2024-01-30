using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportPourTous.Application.Interfaces
{
    public interface IDeleteReservationCommandHandler
    {
        Task Handle(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportPourTous.Infrastructure.Exceptions
{
    public class ReservationNotFoundException : Exception
    {
        public ReservationNotFoundException(Guid id) : base($"No reservation found with ID {id}.") { }
    }
}

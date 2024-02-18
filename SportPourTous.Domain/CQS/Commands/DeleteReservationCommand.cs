using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportPourTous.Domain.CQS.Commands
{
    public class DeleteReservationCommand
    {
        public Guid Id { get; set; }
    }
}

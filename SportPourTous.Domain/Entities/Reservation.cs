using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportPourTous.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime BeginningHour { get; set; }
        public DateTime EndingHour { get; set; }
        public Reservation() { }
    }
}

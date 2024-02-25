using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; init; }
        public DateTime ReservationDate { get; set; }
        public DateTime BeginningHour { get; set; }
        public DateTime EndingHour { get; set; }
        public Prestation? Prestation { get; set; }
    }
}

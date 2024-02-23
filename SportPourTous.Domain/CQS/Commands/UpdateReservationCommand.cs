namespace SportPourTous.Domain.CQS.Commands
{
    public class UpdateReservationCommand
    {
        public DateTime ReservationDate { get; set; }
        public DateTime BeginningHour { get; set; }
        public DateTime EndingHour { get; set;}
    }
}
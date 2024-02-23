namespace SportPourTous.Web.DTO
{
    public class UpdateReservationDto
    {
        public DateTime ReservationDate { get; set; }
        public DateTime BeginningHour { get; set; }
        public DateTime EndingHour { get; set; }
    }
}
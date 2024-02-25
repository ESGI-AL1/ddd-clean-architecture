namespace SportPourTous.Web.DTO
{
    public class CreateReservationDto
    {
        public DateTime ReservationDate { get; set; }
        public DateTime BeginningHour { get; set; }
        public DateTime EndingHour { get; set; }
        public bool? MealTray { get; set; }
        public bool? BusAccess { get; set; } 
    }
}

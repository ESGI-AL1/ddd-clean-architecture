namespace SportPourTous.Web.DTO
{
    public class ReservationResponseDto
    {
        public Guid Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime BeginningHour { get; set; }
        public DateTime EndingHour { get; set; }
        public PrestationDto? Prestation { get; set; } 

    }
}

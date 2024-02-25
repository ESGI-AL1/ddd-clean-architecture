namespace SportPourTous.Infrastructure.Exceptions
{
    public class ReservationNotFoundException : Exception
    {
        public ReservationNotFoundException(Guid id) : base($"No reservation found with ID {id}.") { }
    }
}

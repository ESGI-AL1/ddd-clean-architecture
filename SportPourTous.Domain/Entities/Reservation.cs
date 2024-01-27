using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Domain.Entities;
/*
 * Reservation is an Entity
 * It is at the core of the domain
 * We can track this entity during the lifecycle of the application
 */
public class Reservation
{
    public ReservationId ReservationId { get; init; }
    public ClientId ClientId { get; set; } 
    public DateOnly Date { get; set; }
    public DateTime BeginningHour { get; set; }
    public DateTime EndingHour { get; set; }
    public Location Location { get; set; }
    public List<Equipement>? Equipement { get; set; }
    public List<Prestation>? Prestation { get; set; }
    
    public Reservation(DateOnly date, DateTime beginningHour, DateTime endingHour, Location location, ClientId clientId)
    {
        if (endingHour <= beginningHour)
        {
            throw new ArgumentException("Invalid ending hour.");
        }

        ReservationId = new ReservationId();
        ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId), "ClientId cannot be null.");
        Date = date;
        BeginningHour = beginningHour;
        EndingHour = endingHour;
        Location = location ?? throw new ArgumentNullException(nameof(location),
            "Location cannot be null.");    }
}
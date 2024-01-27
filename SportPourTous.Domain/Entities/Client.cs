using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Domain.Entities;
/*
 * Client is an Entity
 * It is unique and at the core of the domain
 * We can track this entity during the lifecycle of the application
 */
public class Client
{
    public ClientId ClientId { get; init; } = new ClientId();
    public string Name { get; set; }
    public bool IsFirstRegistration { get; set; }
    public List<Reservation> Reservations { get; set; }

    public Client(string name, bool isFirstRegistration = true)
    {
        Name = name;
        IsFirstRegistration = isFirstRegistration;
    }
}
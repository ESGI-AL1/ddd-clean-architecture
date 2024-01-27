namespace SportPourTous.Domain.ValueObjects;

public class ReservationId
{
    private readonly Guid _id;

    public ReservationId()
    {
        _id = Guid.NewGuid();
    }

    public ReservationId(Guid id)
    {
        _id = id;
    }
    
    public override string ToString()
    {
        return _id.ToString();
    }
    
    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
}
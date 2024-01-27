namespace SportPourTous.Domain.ValueObjects;

public class ClientId
{
    private readonly Guid _id;

    public ClientId()
    {
        _id = Guid.NewGuid();
    }

    public ClientId(Guid id)
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
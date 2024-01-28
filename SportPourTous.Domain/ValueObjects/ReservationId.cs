using System;

namespace SportPourTous.Domain.ValueObjects
{
    public class ReservationId
    {
        public Guid Id { get; private set; }

        public ReservationId()
        {
            Id = Guid.NewGuid();
        }

        public ReservationId(Guid id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public Guid ToGuid()
        {
            return Id;
        }
    }
}
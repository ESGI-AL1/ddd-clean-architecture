using System.ComponentModel.DataAnnotations.Schema;

namespace SportPourTous.Domain.ValueObjects
{
    public class Prestation
    {
        [Column("Meal")]
        public bool Meal { get; private set; }
        
        [Column("Bus")]
        public bool Bus { get; private set; }

        public Prestation(bool meal, bool bus)
        {
            Meal = meal;
            Bus = bus;
        }
    }
}

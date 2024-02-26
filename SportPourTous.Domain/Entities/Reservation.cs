using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; init; }
        public DateTime ReservationDate { get; set; }
        public DateTime BeginningHour { get; set; }
        public DateTime EndingHour { get; set; }
        public Prestation? Prestation { get; set; }
        public Material? Material { get; set; }

       public decimal CalculateTotalCost()
        {
            decimal totalCost = Material.RentalFee;

            foreach (var prestation in Prestation)
            {
                totalCost += prestation.Cost;
            }
            return totalCost;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Domain.Entities
{
    /*
     * Reservation is an Entity
     * It is at the core of the domain
     * We can track this entity during the lifecycle of the application
     */
    public class Reservation
    {
        private ReservationId _reservationId;
        public ReservationId ReservationId
        {
            get
            {
                // Generate a new ReservationId if it's not already assigned
                if (_reservationId == null)
                {
                    _reservationId = new ReservationId();
                }
                return _reservationId;
            }
            set { _reservationId = value; }
        }

        
        [JsonPropertyName("date")]
        [Required]
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }

        [JsonPropertyName("beginning_hour")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BeginningHour { get; set; }

        [JsonPropertyName("ending_hour")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndingHour { get; set; }

        [JsonPropertyName("location_id")] 
        public Guid LocationId { get; set; } 

        [JsonPropertyName("location")]
        [Required]
        public Location Location { get; set; } 
        
        [JsonConstructor]
        public Reservation() {}
    }
}
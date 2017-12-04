using System;

namespace Stations.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public decimal Price
        {
            get => Price;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                        "The value must be greater than 0");
                }
            }
        }

        public string SeatingPlace { get; set; }

        public int CustomerCardId { get; set; }
        public CustomerCard CustomerCard { get; set; }
    }
}
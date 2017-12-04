using System;
using System.Collections.Generic;

namespace Stations.Models
{
    public class CustomerCard
    {
        public CustomerCard()
        {
            Tickets = new List<Ticket>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? Age
        {
            get
            {
                return Age;
            }
            set
            {
                if (value < 0 && value > 120)
                {
                    throw new ArgumentOutOfRangeException("value",
                        "The value must be greater than 0 and lower than 120");
                }
            }
        }

        public CardType CardType { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}

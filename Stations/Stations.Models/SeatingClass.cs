using System.Collections.Generic;

namespace Stations.Models
{
    public class SeatingClass
    {
        public SeatingClass()
        {
            TrainSeatses = new List<TrainSeat>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public ICollection<TrainSeat> TrainSeatses { get; set; }
    }
}
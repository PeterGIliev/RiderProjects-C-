using System.Collections.Generic;

namespace Stations.Models
{
    public class Train
    {
        public Train()
        {
            TrainSeatses = new List<TrainSeat>();
        }
        
        public int Id { get; set; }
        
        public string TrainNumber { get; set; }

        public Type Type { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public ICollection<TrainSeat> TrainSeatses { get; set; }
    }
}
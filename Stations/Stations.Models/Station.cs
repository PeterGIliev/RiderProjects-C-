using System.Collections.Generic;

namespace Stations.Models
{
    public class Station
    {
        public Station()
        {
            OriginStation = new List<Trip>();
            DestinationStation = new List<Trip>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        public ICollection<Trip> OriginStation { get; set; }

        public ICollection<Trip> DestinationStation { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamBuilder.Models
{
    public class Event
    {
        public Event()
        {
            this.ParticipatingEventTeams = new List<EventTeam>();
        }
        [Column(Order=0)]
        public int Id { get; set; }
        
        [Column(Order=1)]
        public string Name { get; set; }
        
        [Column(Order=2)]
        public string Description { get; set; }
        
        [Column(Order=3)]
        public DateTime StartDate { get; set; }
        
        [Column(Order=4)]
        public DateTime EndDate { get; set; }
        
        [Column(Order=5)]
        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<EventTeam> ParticipatingEventTeams { get; set; }
    }
}
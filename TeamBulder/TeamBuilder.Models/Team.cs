using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            UserTeams = new List<UserTeam>();
            Invitations = new List<Invitation>();
            EventTeams = new List<EventTeam>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(3, MinimumLength = 3)]
        public string Acronym { get; set; }
        
        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<UserTeam> UserTeams { get; set; }

        public ICollection<Invitation> Invitations { get; set; }

        public ICollection<EventTeam> EventTeams { get; set; }
    }
}
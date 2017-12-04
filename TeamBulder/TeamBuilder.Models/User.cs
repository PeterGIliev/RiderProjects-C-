using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TeamBuilder.Models
{
    public class User
    {
        public User()
        {
            TeamsCreated = new List<Team>();
            UserTeams = new List<UserTeam>();
            Invitations = new List<Invitation>();
            EventsCreated = new List<Event>();
        }
        
        public int Id { get; set; }

        [MinLength (3)]
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [MinLength(6)]
        [RegularExpression(@".*[A-Z].*[0-9].*")]
        public string Password { get; set; }

        public Gender Gender { get; set; }
        
        [Range(0, int.MaxValue)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    
        public ICollection<Team> TeamsCreated { get; set; }

        public ICollection<UserTeam> UserTeams { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
        
        public ICollection<Event> EventsCreated { get; set; }
  
    }
}
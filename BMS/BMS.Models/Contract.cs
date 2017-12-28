using System;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Contract
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Body { get; set; }

        public int CreatorId { get; set; }
        public Employee Creator { get; set; }
        
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
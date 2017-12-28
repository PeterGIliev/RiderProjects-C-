using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();
    }
}
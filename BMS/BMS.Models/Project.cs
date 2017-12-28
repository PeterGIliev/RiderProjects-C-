using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }

        [Required]
        public string Name { get; set; }

        public int ClientId { get; set; }
        [Required]
        public Client Client { get; set; }

        public ICollection<Inquire> Inquires { get; set; } = new List<Inquire>();
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();
        public ICollection<ProjectSupplier> ProjectSuppliers { get; set; } = new List<ProjectSupplier>();
    }
}
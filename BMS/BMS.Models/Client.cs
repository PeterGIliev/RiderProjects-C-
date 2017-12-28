using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string VatNumber { get; set; }

        public string Note { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public ICollection<ContactPerson> ContactPersons { get; set; } = new List<ContactPerson>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
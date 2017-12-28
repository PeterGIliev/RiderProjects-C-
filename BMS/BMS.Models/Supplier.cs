using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Address { get; set; }

        public string VatNumber { get; set; }

        public string Note { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public ICollection<ContactPerson> ContactPersons { get; set; } = new List<ContactPerson>();
        public ICollection<ProjectSupplier> ProjectSuppliers { get; set; } = new List<ProjectSupplier>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BMS.Models

{
    public class BankAccount
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]{2}[A-Z]{4}[0-9]{14}$")]
        public string AccountNumber { get; set; }

        [Required]
        public string BankName { get; set; }

        public string BankAddress { get; set; }

        public string SWIFT { get; set; }

        public int? ClientId { get; set; }
        public Client AccountOwnerClient { get; set; }

        public int? SupplierId { get; set; }
        public Supplier AccountOwnerSupplier { get; set; }
    }
}
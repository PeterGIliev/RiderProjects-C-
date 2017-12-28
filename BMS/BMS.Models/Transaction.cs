using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
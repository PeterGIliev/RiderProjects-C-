using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class ContactPerson
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[+]?(359)?(0)?[0-9]{9}$")]
        public string MobileNumber { get; set; }
        
        public int? ClientId { get; set; }
        public Client ClientContact { get; set; }

        public int? SupplierId { get; set; }
        public Supplier SupplierContact { get; set; }
    }
}
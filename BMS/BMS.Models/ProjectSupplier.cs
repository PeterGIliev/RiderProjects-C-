using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class ProjectSupplier
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
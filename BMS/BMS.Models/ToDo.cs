using System;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public string Task { get; set; }

        public int ResponsibleEmployeeId { get; set; }
        [Required]
        public Employee ResponsibleEmployee { get; set; }

        public int RelatedProjectId { get; set; }
        [Required]
        public Project RelatedProject { get; set; }
    }
}
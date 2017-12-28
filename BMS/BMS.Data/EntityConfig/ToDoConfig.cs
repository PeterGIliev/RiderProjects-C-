using BMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.EntityConfig
{
    public class ToDoConfig : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasOne(e => e.ResponsibleEmployee)
                .WithMany(r => r.ToDos)
                .HasForeignKey(e => e.ResponsibleEmployeeId);
            
            builder.HasOne(e => e.RelatedProject)
                .WithMany(r => r.ToDos)
                .HasForeignKey(e => e.RelatedProjectId);
        }
    }
}
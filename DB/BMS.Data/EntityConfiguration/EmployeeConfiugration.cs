﻿namespace BMS.Data.EntityConfiguration
{
    using BMS.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiugration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .IsUnicode();

            builder.Property(e => e.LastName)
                .IsRequired()
                .IsUnicode();
        }
    }
}

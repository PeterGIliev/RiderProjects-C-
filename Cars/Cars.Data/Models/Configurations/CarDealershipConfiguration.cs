using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Data.Models.Configurations
{
    public class CarDealershipConfiguration : IEntityTypeConfiguration<CarDealership>
    {
        public void Configure(EntityTypeBuilder<CarDealership> builder)
        {
            builder
                .HasKey(cd => new {cd.CarId, cd.DealershipId});

            builder
                .HasOne(cd => cd.Car)
                .WithMany(c => c.CarDealerships)
                .HasForeignKey(cd => cd.CarId);
            
            builder
                .HasOne(cd => cd.Dealership)
                .WithMany(c => c.CarDealerships)
                .HasForeignKey(cd => cd.DealershipId);
        }
    }
}
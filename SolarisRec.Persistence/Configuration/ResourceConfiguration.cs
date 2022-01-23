using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarisRec.Persistence.PersistenceModel;
using Enum = SolarisRec.Core.Card.Enums;

namespace SolarisRec.Persistence.Configuration
{
    internal class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");

            builder.HasIndex(r => r.Name).IsClustered(false).IsUnique();

            builder.Property(r => r.Name)
                .IsRequired(true);

            builder.Property(r => r.Name)
                .HasMaxLength(24);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Resource> builder)
        {
            builder.HasData
            (
                new Resource
                {
                    Id = (int)Enum.Resource.Beltian,
                    Name = "Beltian"
                },
                new Resource
                {
                    Id = (int)Enum.Resource.Earthian,
                    Name = "Earthian"
                },
                new Resource
                {
                    Id = (int)Enum.Resource.Martian,
                    Name = "Martian"
                },
                new Resource
                {
                    Id = (int)Enum.Resource.Mercurian,
                    Name = "Mercurian"
                },
                new Resource
                {
                    Id = (int)Enum.Resource.Titanian,
                    Name = "Titanian"
                },
                new Resource
                {
                    Id = (int)Enum.Resource.Venusian,
                    Name = "Venusian"
                },
                new Resource
                {
                    Id = (int)Enum.Resource.Any,
                    Name = "Any"
                }
            );
        }
    }
}
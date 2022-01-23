using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarisRec.Persistence.PersistenceModel;
using Enum = SolarisRec.Core.Card.Enums;

namespace SolarisRec.Persistence.Configuration
{
    internal class FactionConfiguration : IEntityTypeConfiguration<Faction>
    {
        public void Configure(EntityTypeBuilder<Faction> builder)
        {
            builder.ToTable("Factions");

            builder.HasIndex(f => f.Name).IsClustered(false).IsUnique();

            builder.Property(f => f.Name)
                .IsRequired(true);

            builder.Property(f => f.Name)
                .HasMaxLength(24);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Faction> builder)
        {
            builder.HasData
            (
                new Faction
                {
                    Id = (int)Enum.Faction.Belt,
                    Name = "Belt"
                },
                 new Faction
                 {
                     Id = (int)Enum.Faction.Earth,
                     Name = "Earth"
                 },
                new Faction
                {
                    Id = (int)Enum.Faction.Mars,
                    Name = "Mars"
                },
                new Faction
                {
                    Id = (int)Enum.Faction.Mercury,
                    Name = "Mercury"
                },
                new Faction
                {
                    Id = (int)Enum.Faction.Titan,
                    Name = "Titan"
                },               
                new Faction
                {
                    Id = (int)Enum.Faction.Venus,
                    Name = "Venus"
                },
                new Faction
                {
                    Id = (int)Enum.Faction.IncludeMissions,
                    Name = "Mission"
                }
            );
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarisRec.Persistence.PersistenceModel;
using Enum = SolarisRec.Core.Card.Enums;

namespace SolarisRec.Persistence.Configuration
{
    internal class TalentConfiguration : IEntityTypeConfiguration<Talent>
    {
        public void Configure(EntityTypeBuilder<Talent> builder)
        {
            builder.ToTable("Talents");

            builder.HasIndex(t => t.Name).IsClustered(false).IsUnique();

            builder.Property(t => t.Name)
                .IsRequired(true);

            builder.Property(t => t.Name)
                .HasMaxLength(24);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Talent> builder)
        {
            builder.HasData
            (
                 new Talent
                 {
                     Id = (int)Enum.Talent.Data,
                     Name = "Data"
                 },
                 new Talent
                 {
                     Id = (int)Enum.Talent.Diplomacy,
                     Name = "Diplomacy"
                 },
                 new Talent
                 {
                     Id = (int)Enum.Talent.Espionage,
                     Name = "Espionage"
                 },               
                new Talent
                {
                    Id = (int)Enum.Talent.Military,
                    Name = "Military"
                },
                new Talent
                {
                    Id = (int)Enum.Talent.Mining,
                    Name = "Mining"
                },
                new Talent
                {
                    Id = (int)Enum.Talent.Research,
                    Name = "Research"
                },
                new Talent
                {
                    Id = (int)Enum.Talent.Any,
                    Name = "Any"
                }
            );
        }
    }
}
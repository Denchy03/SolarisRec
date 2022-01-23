using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarisRec.Persistence.PersistenceModel;

namespace SolarisRec.Persistence.Configuration
{
    internal class DeckItemConfiguration : IEntityTypeConfiguration<DeckItem>
    {
        public void Configure(EntityTypeBuilder<DeckItem> builder)
        {
            builder.ToTable("DeckItems");

            builder.Property(d => d.DeckId)
                .IsRequired(true);

            builder.Property(d => d.CardId)
                .IsRequired(true);            

            builder.Property(d => d.DeckType)
                .IsRequired(true);

            builder.Property(d => d.Quantity)
                .IsRequired(true);
        }
    }
}
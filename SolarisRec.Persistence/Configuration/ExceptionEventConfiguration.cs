using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarisRec.Persistence.PersistenceModel;

namespace SolarisRec.Persistence.Configuration
{
    internal class ExceptionEventConfiguration : IEntityTypeConfiguration<ExceptionEvent>
    {
        public void Configure(EntityTypeBuilder<ExceptionEvent> builder)
        {
            builder.ToTable("ExceptionEvents");
        }
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Configuration;

namespace Infraestructure.Persistence.Configurations.Configuration;

public class ConceptoConfiguration : IEntityTypeConfiguration<Concepto>
{
    public void Configure(EntityTypeBuilder<Concepto> builder)
    {
        builder.ToTable("Concepto", "Configuracion");

        builder.HasKey(a => a.Id);
    }
}

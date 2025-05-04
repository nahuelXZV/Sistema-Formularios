using EntidadModel = Domain.Entities.Configuration.Entidad;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Configurations.Configuration;

public class EntidadConfiguration : IEntityTypeConfiguration<EntidadModel>
{
    public void Configure(EntityTypeBuilder<EntidadModel> builder)
    {
        builder.ToTable("Entidad", "Configuracion");

        builder.HasKey(a => a.Id);
    }
}

using Domain.Entities.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Configurations.Forms;

public class GrupoFormularioConfiguration : IEntityTypeConfiguration<GrupoFormulario>
{
    public void Configure(EntityTypeBuilder<GrupoFormulario> builder)
    {
        builder.ToTable("GrupoFormulario", "Formulario");

        builder.HasKey(a => a.Id);
    }
}
using Domain.Entities.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Configurations.Forms;

public class RespuestaFormularioConfiguration : IEntityTypeConfiguration<RespuestaFormulario>
{
    public void Configure(EntityTypeBuilder<RespuestaFormulario> builder)
    {
        builder.ToTable("RespuestaFormulario", "Formulario");

        builder.HasKey(a => a.Id);
    }
}
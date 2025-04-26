using Domain.Entities.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Configurations.Forms;

public class RespuestaGrupoConfiguration : IEntityTypeConfiguration<RespuestaGrupo>
{
    public void Configure(EntityTypeBuilder<RespuestaGrupo> builder)
    {
        builder.ToTable("RespuestaGrupo", "Formulario");

        builder.HasKey(a => a.Id);
    }
}
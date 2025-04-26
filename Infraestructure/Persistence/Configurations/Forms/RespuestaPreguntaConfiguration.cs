using Domain.Entities.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Configurations.Forms;

public class RespuestaPreguntaConfiguration : IEntityTypeConfiguration<RespuestaPregunta>
{
    public void Configure(EntityTypeBuilder<RespuestaPregunta> builder)
    {
        builder.ToTable("RespuestaPregunta", "Formulario");

        builder.HasKey(a => a.Id);
    }
}
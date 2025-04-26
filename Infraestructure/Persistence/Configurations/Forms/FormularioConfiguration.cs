using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Forms;

namespace Infraestructure.Persistence.Configurations.Forms;

public class FormularioConfiguration : IEntityTypeConfiguration<Formulario>
{
    public void Configure(EntityTypeBuilder<Formulario> builder)
    {
        builder.ToTable("Formulario", "Formulario");

        builder.HasKey(a => a.Id);
    }
}
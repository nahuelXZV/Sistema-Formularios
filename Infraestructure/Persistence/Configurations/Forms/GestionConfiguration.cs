using Domain.Entities.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Configurations.Forms;

public class GestionConfiguration : IEntityTypeConfiguration<Gestion>
{
    public void Configure(EntityTypeBuilder<Gestion> builder)
    {
        builder.ToTable("Gestion", "Formulario");

        builder.HasKey(a => a.Id);
    }
}
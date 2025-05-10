using Domain.Entities.Forms;

namespace Domain.DTOs.Forms;

public class GrupoDTO
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Activo { get; set; }

    public List<GrupoFormularioDTO> ListaFormularios { get; set; } = new();
}

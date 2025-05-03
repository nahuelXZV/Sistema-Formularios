
namespace Domain.DTOs.Forms;

public class GestionDTO
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool Activo { get; set; }
    public bool Terminado { get; set; }
}


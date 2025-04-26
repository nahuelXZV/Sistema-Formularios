using Domain.Common;

namespace Domain.Entities.Forms;

public class Grupo : Entity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Activo { get; set; }

}

using Domain.Common;
using Domain.Entities.Configuration;

namespace Domain.Entities.Forms;

public class RespuestaGrupo : Entity
{
    public DateTime Fecha { get; set; }
    public double Puntuacion { get; set; }
    public long EntidadId { get; set; }
    public long GrupoId { get; set; }
    public long GestionId { get; set; }

    public Gestion Gestion { get; set; }
    public Entidad Entidad { get; set; }
    public Grupo Grupo { get; set; }
}

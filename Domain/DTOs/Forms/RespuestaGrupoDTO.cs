using Domain.DTOs.Configuration;

namespace Domain.DTOs.Forms;

public class RespuestaGrupoDTO
{
    public long Id { get; set; }
    public DateTime? Fecha { get; set; }
    public double Puntuacion { get; set; }
    public long EntidadId { get; set; }
    public long GrupoId { get; set; }
    public long GestionId { get; set; }

    public GestionDTO? Gestion { get; set; }
    public EntidadDTO? Entidad { get; set; }
    public GrupoDTO? Grupo { get; set; }
}

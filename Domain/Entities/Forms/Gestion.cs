
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities.Forms;

public class Gestion : Entity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool Activo { get; set; }
    public bool Terminado { get; set; }


    [NotMapped]
    List<RespuestaGrupo> ListaRespuestas { get; set; }
}

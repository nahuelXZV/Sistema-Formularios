using Domain.Common;

namespace Domain.Entities.Forms;

public class RespuestaFormulario : Entity
{
    public DateTime Fecha { get; set; }
    public double GradoCumplimiento { get; set; }
    public string Observaciones { get; set; }
    public double Resultado { get; set; }
    public long FormularioId { get; set; }
    public long RespuestaGrupoId { get; set; }

    public Formulario Formulario { get; set; }
    public List<RespuestaPregunta> ListaRespuestas { get; set; }
}

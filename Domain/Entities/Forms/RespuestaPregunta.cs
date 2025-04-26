
using Domain.Common;

namespace Domain.Entities.Forms;

public class RespuestaPregunta : Entity
{
    public string Respuesta { get; set; }
    public long RespuestaFormularioId { get; set; }
    public long PreguntaId { get; set; }

    public Pregunta Pregunta { get; set; }
}

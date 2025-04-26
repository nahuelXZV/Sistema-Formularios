using Domain.Common;

namespace Domain.Entities.Forms;

public class Formulario : Entity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double Ponderacion { get; set; }
    public short Orden { get; set; }
    public bool Activo { get; set; }

    public List<Pregunta> ListaPreguntas { get; set; }
}

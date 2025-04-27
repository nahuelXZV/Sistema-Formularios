
using Domain.Common;

namespace Domain.Entities.Forms;

public class GrupoFormulario : Entity
{
    public long GrupoId { get; set; }
    public long FormularioId { get; set; }


    public Formulario Formulario { get; set; }
}


namespace Domain.Entities.Forms;

public class GrupoFormulario
{
    public long GrupoId { get; set; }
    public long FormularioId { get; set; }


    public Formulario Formulario { get; set; }
}

namespace Domain.DTOs.Forms;

public class GrupoFormularioDTO
{
    public long Id { get; set; }
    public long GrupoId { get; set; }
    public long FormularioId { get; set; }

    public FormularioDTO? Formulario { get; set; }
}
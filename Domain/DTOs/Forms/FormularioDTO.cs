namespace Domain.DTOs.Forms;

public class FormularioDTO
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double Ponderacion { get; set; }
    public short Orden { get; set; }
    public bool Activo { get; set; }

    public List<PreguntaDTO> ListaPreguntas { get; set; }
}

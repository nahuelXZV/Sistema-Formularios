namespace Domain.DTOs.Forms;

public class PreguntaDTO
{
    public long Id { get; set; }
    public string Enunciado { get; set; }
    public string Descripcion { get; set; }
    public short Orden { get; set; }
    public double Ponderacion { get; set; }
    public bool Activo { get; set; }
    public bool Requerido { get; set; }
    public string Opciones { get; set; } = String.Empty;
    public short TipoId { get; set; }
    public long FormularioId { get; set; }

    public PreguntaDTO() { }

    public PreguntaDTO(PreguntaDTO other)
    {
        Id = other.Id;
        Enunciado = other.Enunciado;
        Descripcion = other.Descripcion;
        Orden = other.Orden;
        Ponderacion = other.Ponderacion;
        Activo = other.Activo;
        Requerido = other.Requerido;
        Opciones = other.Opciones;
        TipoId = other.TipoId;
        FormularioId = other.FormularioId;
    }

}

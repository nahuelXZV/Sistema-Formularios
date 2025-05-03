using Domain.Entities.Configuration;

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
    public string Opciones { get; set; }
    public short TipoId { get; set; }
    public long FormularioId { get; set; }

    public Concepto Tipo { get; set; }
}

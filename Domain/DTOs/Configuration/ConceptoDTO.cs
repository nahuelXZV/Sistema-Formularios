namespace Domain.DTOs.Configuration;

public class ConceptoDTO
{
    public long Id { get; set; }
    public int Tipo { get; set; }
    public string Clave { get; set; }
    public string Nombre { get; set; }
    public string Valor { get; set; }
    public string Descripcion { get; set; }
    public int Secuencia { get; set; }
    public bool Editable { get; set; }
}

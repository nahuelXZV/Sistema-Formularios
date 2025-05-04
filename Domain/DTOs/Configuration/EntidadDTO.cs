namespace Domain.DTOs.Configuration;

public class EntidadDTO
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Direccion { get; set; } = String.Empty;
    public string Latitud { get; set; } = String.Empty;
    public string Longitud { get; set; } = String.Empty;
    public string Telefono { get; set; } = String.Empty;
    public string Correo { get; set; } = String.Empty;
}

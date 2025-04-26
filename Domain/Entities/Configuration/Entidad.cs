using Domain.Common;

namespace Domain.Entities.Configuration;

public class Entidad : Entity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Direccion { get; set; }
    public string Latitud { get; set; }
    public string Longitud { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
}

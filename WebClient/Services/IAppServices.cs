using Domain.Interfaces.Services.Configuration;
using Domain.Interfaces.Services.Forms;
using Domain.Interfaces.Services.Segurity;

namespace WebClient.Services;

public interface IAppServices
{
    public ISesionService SesionService { get; }
    public IPerfilService PerfilService { get; }
    public IModuloService ModuloService { get; }
    public IUsuarioService UsuarioService { get; }

    public IEntidadService EntidadService { get; }

    public IGestionService GestionService { get; }
    public IFormularioService FormularioService { get; }

}

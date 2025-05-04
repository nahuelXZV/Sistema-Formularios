using Domain.Interfaces.Services.Configuration;
using Domain.Interfaces.Services.Forms;
using Domain.Interfaces.Services.Segurity;

namespace WebClient.Services.Implementacion;

public class AppServices : IAppServices
{
    private readonly ILogger<AppServices> _logger;

    private readonly IServiceProvider _serviceProvider;

    private ISesionService _sesionService;
    private IPerfilService _perfilService;
    private IModuloService _moduloService;
    private IUsuarioService _usuarioService;
    private IConceptoService _conceptoService;
    private IEntidadService _entidadService;
    private IGestionService _gestionService;
    private IFormularioService _formularioService;


    public AppServices(IServiceProvider serviceProvider, ILogger<AppServices> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    #region SEGURITY
    public ISesionService SesionService => _sesionService ??= _serviceProvider.GetService<ISesionService>();
    public IPerfilService PerfilService => _perfilService ??= _serviceProvider.GetService<IPerfilService>();
    public IModuloService ModuloService => _moduloService ??= _serviceProvider.GetService<IModuloService>();
    public IUsuarioService UsuarioService => _usuarioService ??= _serviceProvider.GetService<IUsuarioService>();
    #endregion

    #region CONFIGURACION
    public IConceptoService ConceptoService => _conceptoService ??= _serviceProvider.GetService<IConceptoService>();
    public IEntidadService EntidadService => _entidadService ??= _serviceProvider.GetService<IEntidadService>();
    #endregion

    #region FORMULARIOS
    public IGestionService GestionService => _gestionService ??= _serviceProvider.GetService<IGestionService>();
    public IFormularioService FormularioService => _formularioService ??= _serviceProvider.GetService<IFormularioService>();
    #endregion
}
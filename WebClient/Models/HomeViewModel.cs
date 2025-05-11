using Domain.DTOs.Configuration;
using Domain.DTOs.Forms;

namespace WebClient.Models;

public class HomeViewModel : MainViewModel
{
    public List<EntidadDTO> ListaEmpresas { get; set; } = new();
    public List<GestionDTO> ListaGestiones { get; set; } = new();
    public List<GrupoDTO> ListaGrupos { get; set; } = new();

    public HomeViewModel() { }
}

using Domain.DTOs.Forms;

namespace WebClient.Models.Forms;

public class GrupoViewModel : MainViewModel
{
    public GrupoDTO Grupo { get; set; }
    public List<FormularioDTO> ListaFormularios { get; set; }

    public GrupoViewModel() : base() { }
}

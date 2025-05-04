using Domain.DTOs.Configuration;
using Domain.DTOs.Forms;

namespace WebClient.Models.Forms;

public class FormularioViewModel : MainViewModel
{
    public FormularioDTO Formulario { get; set; }

    public FormularioViewModel() : base() { }
}

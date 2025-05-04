using Domain.DTOs.Forms;

namespace WebClient.Models.Forms;

public class GestionViewModel : MainViewModel
{
    public GestionDTO Gestion { get; set; }

    public GestionViewModel() : base() { }
}

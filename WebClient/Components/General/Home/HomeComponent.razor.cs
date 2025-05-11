using Domain.DTOs.Configuration;
using Domain.DTOs.Forms;
using Microsoft.AspNetCore.Components;

namespace WebClient.Components.General.Home;

public partial class HomeComponent
{
    [Parameter] public List<EntidadDTO> ListaEmpresas { get; set; } = new();
    [Parameter] public List<GestionDTO> ListaGestiones { get; set; } = new();
    [Parameter] public List<GrupoDTO> ListaGrupos { get; set; } = new();
    public RespuestaGrupoDTO RespuestaGrupo { get; set; } = new();
    public long GestionIdSeleccionado { get; set; }
    public List<RespuestaGrupoDTO> ListaRespuestas { get; set; } = new();

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        RespuestaGrupo.GrupoId = ListaGrupos.FirstOrDefault()?.Id ?? 0;
        RespuestaGrupo.GestionId = ListaGestiones.FirstOrDefault()?.Id ?? 0;
        RespuestaGrupo.EntidadId = ListaEmpresas.FirstOrDefault()?.Id ?? 0;

        GestionIdSeleccionado = ListaGestiones.FirstOrDefault()?.Id ?? 0;
        await ObtenerRespuestas();
        StateHasChanged();
    }

    public async Task ObtenerRespuestas()
    {
        PaginaActual = 1;
        ListaRespuestas = await AppServices.RespuestaGrupoService.GetByGestion(GestionIdSeleccionado);
        StateHasChanged();
    }


    public async Task VerRespuesta(long id)
    {
    }

    public async Task CrearRespuesta()
    {
        try
        {
            RespuestaGrupo.Fecha = DateTime.Now;
            await AppServices.RespuestaGrupoService.Create(RespuestaGrupo);

            await ObtenerRespuestas();
            await ShowSuccessMessage("Guardado correctamente");
            //await Task.Delay(1000);
            //Navigation.NavigateTo($"{AdminConfig.General.WebUrl}Gestion/listado", true);
        }
        catch (Exception ex)
        {
            await ShowErrorMessage(ex.Message);
        }
    }

    #region Paginado
    private int PaginaActual { get; set; } = 1;
    private int TamanoPagina { get; set; } = 5;
    private bool PuedeRetroceder => PaginaActual > 1;
    private bool PuedeAvanzar => PaginaActual < TotalPaginas;

    private int TotalPaginas => (int)Math.Ceiling((double)ListaRespuestas.Count / TamanoPagina);

    private IEnumerable<RespuestaGrupoDTO> ListaRespuestasPaginada => ListaRespuestas
                                            .Skip((PaginaActual - 1) * TamanoPagina)
                                            .Take(TamanoPagina);

    private void PaginaAnterior()
    {
        if (PaginaActual > 1)
            PaginaActual--;
    }

    private void PaginaSiguiente()
    {
        if (PaginaActual < TotalPaginas)
            PaginaActual++;
    }

    #endregion
}
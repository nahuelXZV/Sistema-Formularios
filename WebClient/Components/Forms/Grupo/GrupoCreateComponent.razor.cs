using Domain.DTOs.Forms;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WebClient.Components.Shared.Base;

namespace WebClient.Components.Forms.Grupo;

public partial class GrupoCreateComponent
{
    [Inject] public NavigationManager Navigation { get; set; }
    [Inject] public IValidator<GrupoDTO> Validator { get; set; }
    [Parameter] public GrupoDTO Grupo { get; set; }
    [Parameter] public List<FormularioDTO> ListaFormularios { get; set; } = new();

    private ValidatorHelper<GrupoDTO> _validatorHelper;
    private DotNetObjectReference<GrupoCreateComponent> _objectHelper;
    public long FormularioIdSeleccionado { get; set; }
    public List<FormularioDTO> ListaFormulariosAsociados { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _validatorHelper = new ValidatorHelper<GrupoDTO>(Validator);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        if (Grupo.Id != 0) await ModoEdicion();
        await InicializarJSHelper();
    }

    private async Task ModoEdicion()
    {
        var listaIdsFormularios = Grupo.ListaFormularios.Select(x => x.FormularioId).ToList();
        ListaFormulariosAsociados = ListaFormularios.Where(x => listaIdsFormularios.Contains(x.Id)).ToList();
        ListaFormularios = ListaFormularios.Where(x => !listaIdsFormularios.Contains(x.Id)).ToList();
        StateHasChanged();
    }

    private async Task InicializarJSHelper()
    {
        try
        {
            _objectHelper = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("GrupoCreateComponent.init", _objectHelper);
        }
        catch (Exception)
        {
            await JSRuntime.InvokeVoidAsync("console.warn", $"No se pudo inicializar JSHelper para componente: {nameof(GrupoCreateComponent)}");
        }
    }

    public async Task DesvincularFormulario(long id)
    {
        var formulario = ListaFormulariosAsociados.FirstOrDefault(x => x.Id == id);
        if (formulario != null)
        {
            ListaFormulariosAsociados.Remove(formulario);
            ListaFormularios.Add(formulario);
        }
        StateHasChanged();
    }


    public async Task RegistrarFormulario()
    {
        if (FormularioIdSeleccionado == 0)
        {
            await ShowErrorMessage("Seleccione un formulario");
            return;
        }
        var formulario = ListaFormularios.FirstOrDefault(x => x.Id == FormularioIdSeleccionado);
        if (formulario != null)
        {
            ListaFormulariosAsociados.Add(formulario);
            ListaFormularios.Remove(formulario);
            FormularioIdSeleccionado = 0;
        }
        StateHasChanged();
    }


    [JSInvokable]
    public async Task Guardar()
    {
        if (!await _validatorHelper.Validar(Grupo))
        {
            StateHasChanged(); return;
        }

        try
        {
            Grupo.ListaFormularios = ListaFormulariosAsociados.Select(x => new GrupoFormularioDTO
            {
                FormularioId = x.Id,
            }).ToList();

            if (Grupo.Id != 0)
            {
                var respuesta = await AppServices.GrupoService.Update(Grupo);
            }
            else
            {
                Grupo.FechaCreacion = DateTime.Now;
                var respuesta = await AppServices.GrupoService.Create(Grupo);
            }

            await ShowSuccessMessage("Grupo guardado correctamente");
            await Task.Delay(1000);
            Navigation.NavigateTo($"{AdminConfig.General.WebUrl}Grupo/listado", true);
        }
        catch (Exception ex)
        {
            await ShowErrorMessage(ex.Message);
        }
    }
}

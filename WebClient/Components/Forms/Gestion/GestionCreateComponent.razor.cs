using Domain.DTOs.Forms;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WebClient.Components.Shared.Base;
using WebClient.Configs;

namespace WebClient.Components.Forms.Gestion;

public partial class GestionCreateComponent
{
    [Inject] public NavigationManager Navigation { get; set; }
    [Inject] public IValidator<GestionDTO> Validator { get; set; }
    [Parameter] public GestionDTO Gestion { get; set; }
    private ValidatorHelper<GestionDTO> _validatorHelper;
    private DotNetObjectReference<GestionCreateComponent> _objectHelper;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _validatorHelper = new ValidatorHelper<GestionDTO>(Validator);
        if (Gestion.Id != 0) await ModoEdicion();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;
        await InicializarJSHelper();
    }

    private async Task ModoEdicion()
    {
        //ListaAccesosSeleccionados = Perfil.ListaAccesos.Select(a => a.AccesoId).ToList();
    }

    private async Task InicializarJSHelper()
    {
        try
        {
            _objectHelper = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("GestionCreateComponent.init", _objectHelper);
        }
        catch (Exception)
        {
            await JSRuntime.InvokeVoidAsync("console.warn", $"No se pudo inicializar JSHelper para componente: {nameof(GestionCreateComponent)}");
        }
    }


    [JSInvokable]
    public async Task Guardar()
    {
        if (!await _validatorHelper.Validar(Gestion))
        {
            StateHasChanged(); return;
        }

        try
        {
            if (Gestion.Id != 0)
            {
                var respuesta = await AppServices.GestionService.Update(Gestion);
            }
            else
            {
                var respuesta = await AppServices.GestionService.Create(Gestion);
            }

            await ShowSuccessMessage("Gestion guardado correctamente");
            await Task.Delay(1000);
            Navigation.NavigateTo($"{AdminConfig.General.WebUrl}Gestion/listado", true);
        }
        catch (Exception ex)
        {
            await ShowErrorMessage(ex.Message);
        }
    }
}

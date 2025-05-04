using Domain.DTOs.Configuration;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WebClient.Components.Shared.Base;

namespace WebClient.Components.Configuration.Entidad;

public partial class EntidadCreateComponent
{
    [Inject] public NavigationManager Navigation { get; set; }
    [Inject] public IValidator<EntidadDTO> Validator { get; set; }
    [Parameter] public EntidadDTO Entidad { get; set; }
    private ValidatorHelper<EntidadDTO> _validatorHelper;
    private DotNetObjectReference<EntidadCreateComponent> _objectHelper;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _validatorHelper = new ValidatorHelper<EntidadDTO>(Validator);
        if (Entidad.Id != 0) await ModoEdicion();
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
            await JSRuntime.InvokeVoidAsync("EntidadCreateComponent.init", _objectHelper);
        }
        catch (Exception)
        {
            await JSRuntime.InvokeVoidAsync("console.warn", $"No se pudo inicializar JSHelper para componente: {nameof(EntidadCreateComponent)}");
        }
    }


    [JSInvokable]
    public async Task Guardar()
    {
        if (!await _validatorHelper.Validar(Entidad))
        {
            StateHasChanged(); return;
        }

        try
        {
            if (Entidad.Id != 0)
            {
                var respuesta = await AppServices.EntidadService.Update(Entidad);
            }
            else
            {
                var respuesta = await AppServices.EntidadService.Create(Entidad);
            }

            await ShowSuccessMessage("Gestion guardado correctamente");
            await Task.Delay(1000);
            Navigation.NavigateTo($"{AdminConfig.General.WebUrl}Entidad/listado", true);
        }
        catch (Exception ex)
        {
            await ShowErrorMessage(ex.Message);
        }
    }
}

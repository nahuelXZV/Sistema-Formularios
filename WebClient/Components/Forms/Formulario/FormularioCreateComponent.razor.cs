using System.Text.Json;
using Domain.Constants;
using Domain.DTOs.Forms;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WebClient.Components.Shared.Base;
using WebClient.Models.Shared;

namespace WebClient.Components.Forms.Formulario;

public partial class FormularioCreateComponent
{
    [Inject] public NavigationManager Navigation { get; set; }
    [Inject] public IValidator<FormularioDTO> Validator { get; set; }
    [Inject] public IValidator<PreguntaDTO> ValidatorPregunta { get; set; }
    [Parameter] public FormularioDTO Formulario { get; set; }

    public List<SelectorGenerico<short>> ListaTipoPreguntas { get; set; } = new();
    private ValidatorHelper<FormularioDTO> _validatorHelper;
    private ValidatorHelper<PreguntaDTO> _validatorHelperPregunta;
    private DotNetObjectReference<FormularioCreateComponent> _objectHelper;

    private long Id { get; set; } = 0;
    public PreguntaDTO Pregunta { get; set; } = new();
    public List<PreguntaDTO> ListaPreguntas { get; set; } = new();
    public bool HabilitarOpciones { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _validatorHelper = new ValidatorHelper<FormularioDTO>(Validator);
        _validatorHelperPregunta = new ValidatorHelper<PreguntaDTO>(ValidatorPregunta);
        InicializarCampos();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        if (Formulario.Id != 0) await ModoEdicion();
        await InicializarJSHelper();
    }

    private void InicializarCampos()
    {
        ListaTipoPreguntas = Enum.GetValues(typeof(TipoPregunta))
                                 .Cast<TipoPregunta>()
                                 .Select(tp => new SelectorGenerico<short>
                                 {
                                     Valor = (short)tp,
                                     Nombre = tp.ToString()
                                 })
                                 .ToList();
    }

    private async Task ModoEdicion()
    {
        ListaPreguntas = Formulario.ListaPreguntas;
        foreach (var pregunta in ListaPreguntas)
        {
            if (!string.IsNullOrEmpty(pregunta.Opciones))
            {
                try
                {
                    var opcionesArray = JsonSerializer.Deserialize<string[]>(pregunta.Opciones);
                    var opcionesTexto = string.Join(",", opcionesArray);
                    pregunta.Opciones = opcionesTexto;
                }
                catch (JsonException)
                {
                    pregunta.Opciones = "";
                }
            }
        }
        StateHasChanged();
    }

    private async Task InicializarJSHelper()
    {
        try
        {
            _objectHelper = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("FormularioCreateComponent.init", _objectHelper);
        }
        catch (Exception)
        {
            await JSRuntime.InvokeVoidAsync("console.warn", $"No se pudo inicializar JSHelper para componente: {nameof(FormularioCreateComponent)}");
        }
    }


    private long GenerarId()
    {
        return Id--;
    }

    public async Task EditarPregunta(long id)
    {
        var preguntaSeleccionada = ListaPreguntas.Where(p => p.Id == id).FirstOrDefault();
        if (preguntaSeleccionada == null)
        {
            await ShowErrorMessage("Pregunta no encontrada");
            return;
        }

        Pregunta = new PreguntaDTO(preguntaSeleccionada);
        if (!string.IsNullOrEmpty(Pregunta.Opciones))
            HabilitarOpciones = true;
        StateHasChanged();
    }

    public void EliminarPregunta(long id)
    {
        ListaPreguntas.RemoveAll(p => p.Id == id);
        StateHasChanged();
    }

    public async Task GuardarPregunta()
    {
        if (!await _validatorHelperPregunta.Validar(Pregunta))
        {
            StateHasChanged();
            return;
        }

        if (Pregunta.Id == 0)
        {
            Pregunta.Id = GenerarId();
            ListaPreguntas.Add(Pregunta);
            LimpiarFormularioPregunta();
            return;
        }

        var index = ListaPreguntas.FindIndex(p => p.Id == Pregunta.Id);
        if (index != -1) ListaPreguntas[index] = Pregunta;
        LimpiarFormularioPregunta();
    }


    private void LimpiarFormularioPregunta()
    {
        Pregunta = new();
        HabilitarOpciones = false;
        StateHasChanged();
    }

    private string ObtenerNombreTipo(short tipo)
    {
        return Enum.GetName(typeof(TipoPregunta), tipo);
    }

    private void FormatearListadoPregunta()
    {
        foreach (var pregunta in ListaPreguntas)
        {
            if (Formulario.Id < 0) pregunta.Id = 0;

            //if (!string.IsNullOrEmpty(pregunta.Opciones) || Formulario.Id == 0)
            //{
            var opcionesArray = pregunta.Opciones
                        .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var opcionesSerializadas = JsonSerializer.Serialize(opcionesArray);
            pregunta.Opciones = opcionesSerializadas;
            //}
        }
        Formulario.ListaPreguntas = ListaPreguntas;
    }


    [JSInvokable]
    public async Task Guardar()
    {
        if (!await _validatorHelper.Validar(Formulario))
        {
            StateHasChanged(); return;
        }

        try
        {
            FormatearListadoPregunta();
            if (Formulario.Id != 0)
            {
                var respuesta = await AppServices.FormularioService.Update(Formulario);
            }
            else
            {
                var respuesta = await AppServices.FormularioService.Create(Formulario);
            }

            await ShowSuccessMessage("Formulario guardado correctamente");
            await Task.Delay(1000);
            Navigation.NavigateTo($"{AdminConfig.General.WebUrl}Formulario/listado", true);
        }
        catch (Exception ex)
        {
            await ShowErrorMessage(ex.Message);
        }
    }
}

using Domain.DTOs.Forms;
using Domain.DTOs.Shared;
using Domain.Interfaces.Services.Forms;
using WebClient.Services.Implementacion;

namespace WebClient.Services.Forms;

public class FormularioService : AppBaseServices, IFormularioService
{
    public FormularioService(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, ILogger<FormularioService> logger)
        : base("api/Formulario", httpClientFactory, contextAccessor, logger)
    {
    }

    public async Task<long> Create(FormularioDTO formulario)
    {
        var uri = $"";
        return await PostAsync<long>(uri, formulario);
    }

    public async Task<bool> Delete(long id)
    {
        var uri = $"Delete/{id}";
        return await DeleteAsync<bool>(uri);
    }

    public async Task<ResponseFilterDTO<FormularioDTO>> GetAll(FilterDTO? filter)
    {
        var uri = AplicarFiltro(filter);
        return await GetAsync<ResponseFilterDTO<FormularioDTO>>(uri);
    }

    public async Task<FormularioDTO> GetById(long id)
    {
        var uri = $"{id}";
        return await GetAsync<FormularioDTO>(uri);
    }

    public async Task<bool> Update(FormularioDTO formulario)
    {
        var uri = $"";
        return await PutAsync<bool>(uri, formulario);
    }
}

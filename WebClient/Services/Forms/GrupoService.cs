using Domain.DTOs.Forms;
using Domain.DTOs.Shared;
using Domain.Interfaces.Services.Forms;
using WebClient.Services.Implementacion;

namespace WebClient.Services.Forms;

public class GrupoService : AppBaseServices, IGrupoService
{
    public GrupoService(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, ILogger<GrupoService> logger)
        : base("api/Grupo", httpClientFactory, contextAccessor, logger)
    {
    }

    public async Task<long> Create(GrupoDTO grupo)
    {
        var uri = $"";
        return await PostAsync<long>(uri, grupo);
    }

    public async Task<bool> Delete(long id)
    {
        var uri = $"Delete/{id}";
        return await DeleteAsync<bool>(uri);
    }

    public async Task<ResponseFilterDTO<GrupoDTO>> GetAll(FilterDTO? filter)
    {
        var uri = AplicarFiltro(filter);
        return await GetAsync<ResponseFilterDTO<GrupoDTO>>(uri);
    }

    public async Task<GrupoDTO> GetById(long id)
    {
        var uri = $"{id}";
        return await GetAsync<GrupoDTO>(uri);
    }

    public async Task<bool> Update(GrupoDTO grupo)
    {
        var uri = $"";
        return await PutAsync<bool>(uri, grupo);
    }
}
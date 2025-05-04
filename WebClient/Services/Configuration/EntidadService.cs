using Domain.DTOs.Configuration;
using Domain.DTOs.Shared;
using Domain.Interfaces.Services.Configuration;
using WebClient.Services.Implementacion;

namespace WebClient.Services.Configuration;

public class EntidadService : AppBaseServices, IEntidadService
{
    public EntidadService(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, ILogger<EntidadService> logger)
        : base("api/Entidad", httpClientFactory, contextAccessor, logger)
    {
    }

    public async Task<long> Create(EntidadDTO entidad)
    {
        var uri = $"";
        return await PostAsync<long>(uri, entidad);
    }

    public async Task<bool> Delete(long id)
    {
        var uri = $"Delete/{id}";
        return await DeleteAsync<bool>(uri);
    }

    public async Task<ResponseFilterDTO<EntidadDTO>> GetAll(FilterDTO? filter)
    {
        var uri = AplicarFiltro(filter);
        return await GetAsync<ResponseFilterDTO<EntidadDTO>>(uri);
    }

    public async Task<EntidadDTO> GetById(long id)
    {
        var uri = $"{id}";
        return await GetAsync<EntidadDTO>(uri);
    }

    public async Task<bool> Update(EntidadDTO entidad)
    {
        var uri = $"";
        return await PutAsync<bool>(uri, entidad);
    }
}

using Domain.DTOs.Forms;
using Domain.DTOs.Shared;
using Domain.Interfaces.Services.Forms;
using WebClient.Services.Implementacion;

namespace WebClient.Services.Forms;

public class GestionService : AppBaseServices, IGestionService
{
    public GestionService(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, ILogger<GestionService> logger)
        : base("api/Gestion", httpClientFactory, contextAccessor, logger)
    {
    }

    public async Task<long> Create(GestionDTO gestion)
    {
        var uri = $"";
        return await PostAsync<long>(uri, gestion);
    }

    public async Task<bool> Delete(long id)
    {
        var uri = $"Delete/{id}";
        return await DeleteAsync<bool>(uri);
    }

    public async Task<ResponseFilterDTO<GestionDTO>> GetAll(FilterDTO? filter)
    {
        var uri = AplicarFiltro(filter);
        return await GetAsync<ResponseFilterDTO<GestionDTO>>(uri);
    }

    public async Task<GestionDTO> GetById(long id)
    {
        var uri = $"{id}";
        return await GetAsync<GestionDTO>(uri);
    }

    public async Task<bool> Update(GestionDTO gestion)
    {
        var uri = $"";
        return await PutAsync<bool>(uri, gestion);
    }
}

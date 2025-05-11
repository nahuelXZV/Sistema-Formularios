using Domain.DTOs.Forms;
using Domain.Interfaces.Services.Forms;
using WebClient.Services.Implementacion;

namespace WebClient.Services.Forms;

public class RespuestaGrupoService : AppBaseServices, IRespuestaGrupoService
{
    public RespuestaGrupoService(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, ILogger<RespuestaGrupoService> logger)
        : base("api/RespuestaGrupo", httpClientFactory, contextAccessor, logger)
    {
    }

    public async Task<long> Create(RespuestaGrupoDTO grupo)
    {
        var uri = $"";
        return await PostAsync<long>(uri, grupo);
    }

    public async Task<bool> Delete(long id)
    {
        var uri = $"Delete/{id}";
        return await DeleteAsync<bool>(uri);
    }

    public async Task<List<RespuestaGrupoDTO>> GetByGestion(long idGestion)
    {
        var uri = $"ByGestion/{idGestion}";
        return await GetAsync<List<RespuestaGrupoDTO>>(uri);
    }

    public async Task<RespuestaGrupoDTO> GetById(long id)
    {
        var uri = $"ById/{id}";
        return await GetAsync<RespuestaGrupoDTO>(uri);
    }

    public async Task<bool> Update(RespuestaGrupoDTO grupo)
    {
        var uri = $"";
        return await PutAsync<bool>(uri, grupo);
    }
}
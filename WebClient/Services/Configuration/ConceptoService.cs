using Domain.DTOs.Configuration;
using Domain.Interfaces.Services.Configuration;
using WebClient.Services.Implementacion;

namespace WebClient.Services.Configuration;

public class ConceptoService : AppBaseServices, IConceptoService
{
    public ConceptoService(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, ILogger<ConceptoService> logger)
        : base("api/Concepto", httpClientFactory, contextAccessor, logger)
    {
    }

    public async Task<List<ConceptoDTO>> GetByTipo(int tipo)
    {
        var uri = $"ByTipo/{tipo}";
        return await GetAsync<List<ConceptoDTO>>(uri);
    }

    public async Task<ConceptoDTO> GetById(long id)
    {
        var uri = $"ById/{id}";
        return await GetAsync<ConceptoDTO>(uri);
    }
}

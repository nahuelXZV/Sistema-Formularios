
using Domain.DTOs.Configuration;

namespace Domain.Interfaces.Services.Configuration;

public interface IConceptoService
{
    Task<ConceptoDTO> GetById(long id);
    Task<List<ConceptoDTO>> GetByTipo(int tipo);
}

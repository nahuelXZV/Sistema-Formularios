using Domain.DTOs.Forms;

namespace Domain.Interfaces.Services.Forms;

public interface IRespuestaGrupoService
{
    Task<long> Create(RespuestaGrupoDTO respuesta);
    Task<bool> Update(RespuestaGrupoDTO respuesta);
    Task<bool> Delete(long id);
    Task<RespuestaGrupoDTO> GetById(long id);
    Task<List<RespuestaGrupoDTO>> GetByGestion(long idGestion);
}

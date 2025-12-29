using Capa.Shared.DTOs;
using Capa.Shared.Responses;

namespace Capa.Backend.Repositories.Intefaces
{
    public interface IDocentesRepository
    {
        Task<ActionResponse<IEnumerable<DocenteModelDTO>>> ConsultaAsync(int carreraId);
    }
}

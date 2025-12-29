using Capa.Shared.DTOs;
using Capa.Shared.Responses;

namespace Capa.Backend.Helpers
{
    public interface IIARecommendationService
    {
        Task<ActionResponse<List<TutorRecomendadoDTO>>> GenerarRecomendacionAsync(
        string tituloProyecto,
        List<DocenteModelDTO> docentes);
    }
}

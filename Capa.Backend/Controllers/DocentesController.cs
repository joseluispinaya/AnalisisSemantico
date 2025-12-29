using Capa.Backend.Helpers;
using Capa.Backend.Repositories.Intefaces;
using Capa.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Capa.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocentesController : ControllerBase
    {
        private readonly IDocentesRepository _docentesRepository;
        private readonly IIARecommendationService _iARecommendationService;
        public DocentesController(IDocentesRepository docentesRepository, IIARecommendationService iARecommendationService)
        {
            _docentesRepository = docentesRepository;
            _iARecommendationService = iARecommendationService;
        }

        [HttpGet("{carreraId:int}")]
        public async Task<IActionResult> GetAsync(int carreraId)
        {
            var action = await _docentesRepository.ConsultaAsync(carreraId);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpPost("Consulta")]
        public async Task<IActionResult> ConsultaAsync([FromBody] ConsultaRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var docentesResponse = await _docentesRepository.ConsultaAsync(request.CarreraId);

            if (!docentesResponse.WasSuccess || docentesResponse.Result == null || !docentesResponse.Result.Any())
                return BadRequest("No se encontraron docentes para la carrera seleccionada.");

            var listaDocentes = docentesResponse.Result!;

            var recomendacion = await _iARecommendationService.GenerarRecomendacionAsync(
                request.TituloPropuesto,
                listaDocentes.ToList());

            if (!recomendacion.WasSuccess)
                return BadRequest(recomendacion.Message);

            return Ok(recomendacion.Result);
        }

    }
}

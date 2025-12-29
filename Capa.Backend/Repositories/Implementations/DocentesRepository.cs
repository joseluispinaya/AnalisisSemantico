using Capa.Backend.Data;
using Capa.Backend.Repositories.Intefaces;
using Capa.Shared.DTOs;
using Capa.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Capa.Backend.Repositories.Implementations
{
    public class DocentesRepository : IDocentesRepository
    {
        private readonly DataContext _context;
        public DocentesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResponse<IEnumerable<DocenteModelDTO>>> ConsultaAsync(int carreraId)
        {
            var docentes = await _context.Docentes
                .Include(d => d.Proyectos)
                .Include(d => d.LineasInvestigacion)
                    .ThenInclude(li => li.LineaInvestigacion)
                .Include(d => d.HistorialTutorias)
                .Where(d => d.CarreraId == carreraId)
                .Select(d => new DocenteModelDTO
                {
                    NombreCompleto = $"{d.Nombres} {d.Apellidos}",
                    ResumenPerfil = d.ResumenPerfil,

                    LineasInvestigacion = d.LineasInvestigacion
                        .Select(x => x.LineaInvestigacion.Nombre)
                        .ToList(),

                    ExperienciaRelevante = d.HistorialTutorias
                        .Where(h => h.Resultado == "Aprobado")
                        .OrderByDescending(h => h.Fecha)
                        .Take(5)
                        .Select(h => $"{h.Tema}")
                        .ToList(),

                    Proyectos = d.Proyectos.Select(p => new ProyectoSimpleDTO
                    {
                        Id = p.Id,
                        Titulo = p.Titulo,
                        Gestion = p.Gestion
                    }).ToList()
                })
                .ToListAsync();

            return new ActionResponse<IEnumerable<DocenteModelDTO>>
            {
                WasSuccess = true,
                Result = docentes
            };
        }
    }
}

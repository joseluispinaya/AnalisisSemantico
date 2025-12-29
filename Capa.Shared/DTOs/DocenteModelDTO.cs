using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Shared.DTOs
{
    public class DocenteModelDTO
    {
        //public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string ResumenPerfil { get; set; } = null!;
        public List<string> LineasInvestigacion { get; set; } = [];
        public List<string> ExperienciaRelevante { get; set; } = [];
        public List<ProyectoSimpleDTO> Proyectos { get; set; } = [];
    }
}

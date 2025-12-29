using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Shared.Entities
{
    public class ProyectoGrado
    {
        public int Id { get; set; }

        [MaxLength(400, ErrorMessage = "El campo Titulo debe tener máximo 400 caractéres.")]
        [Required(ErrorMessage = "El campo Titulo es obligatorio.")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "El campo Resumen es obligatorio.")]
        public string Resumen { get; set; } = null!;

        [MaxLength(4, ErrorMessage = "El campo Gestion debe tener máximo 4 caracteres.")]
        [Required(ErrorMessage = "El campo Gestion es obligatorio.")]
        public string Gestion { get; set; } = null!;

        public int DocenteId { get; set; }
        public Docente Docente { get; set; } = null!;

        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; } = null!;

        public int? LineaInvestigacionId { get; set; }
        public LineaInvestigacion? LineaInvestigacion { get; set; }
    }
}

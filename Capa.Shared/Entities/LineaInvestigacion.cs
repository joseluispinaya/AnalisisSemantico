using System.ComponentModel.DataAnnotations;

namespace Capa.Shared.Entities
{
    public class LineaInvestigacion
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 carácteres.")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public ICollection<DocenteLineaInvestigacion> Docentes { get; set; } = [];
        public ICollection<ProyectoGrado> Proyectos { get; set; } = [];
    }
}

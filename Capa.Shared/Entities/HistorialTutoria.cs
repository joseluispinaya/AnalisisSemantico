using System.ComponentModel.DataAnnotations;

namespace Capa.Shared.Entities
{
    public class HistorialTutoria
    {
        public int Id { get; set; }

        public int DocenteId { get; set; }
        public Docente Docente { get; set; } = null!;

        [MaxLength(400, ErrorMessage = "El campo Tema debe tener máximo 400 caractéres.")]
        [Required(ErrorMessage = "El campo Tema es obligatorio.")]
        public string Tema { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "El campo Carrera debe tener máximo 50 caracteres.")]
        [Required(ErrorMessage = "El campo Carrera es obligatorio.")]
        public string Carrera { get; set; } = null!;

        [MaxLength(20, ErrorMessage = "El campo Resultado debe tener máximo 20 caracteres.")]
        [Required(ErrorMessage = "El campo Resultado es obligatorio.")]
        public string Resultado { get; set; } = null!; // Aprobado, Reprobado, EnProceso

        public DateTime Fecha { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Capa.Shared.Entities
{
    public class Docente
    {
        public int Id { get; set; }

        [MaxLength(10, ErrorMessage = "El campo Nro Cedula debe tener máximo 10 caractéres.")]
        [Required(ErrorMessage = "El campo Nro Cedula es obligatorio.")]
        public string NroCi { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "El campo Nombres debe tener máximo 50 caracteres.")]
        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        public string Nombres { get; set; } = null!;


        [MaxLength(50, ErrorMessage = "El campo Apellidos debe tener máximo 50 caracteres.")]
        [Required(ErrorMessage = "El campo Apellidos es obligatorio.")]
        public string Apellidos { get; set; } = null!;


        [MaxLength(50, ErrorMessage = "El campo Correo debe tener máximo 50 caracteres.")]
        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
        public string Correo { get; set; } = null!;


        [Required(ErrorMessage = "El campo Resumen de Perfil es obligatorio.")]
        public string ResumenPerfil { get; set; } = null!;

        public Carrera Carrera { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Carrera.")]
        public int CarreraId { get; set; }

        public ICollection<ProyectoGrado> Proyectos { get; set; } = [];

        public ICollection<DocenteLineaInvestigacion> LineasInvestigacion { get; set; } = [];
        public ICollection<HistorialTutoria> HistorialTutorias { get; set; } = [];
    }
}

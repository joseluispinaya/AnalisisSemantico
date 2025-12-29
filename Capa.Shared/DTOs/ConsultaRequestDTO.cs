using System.ComponentModel.DataAnnotations;

namespace Capa.Shared.DTOs
{
    public class ConsultaRequestDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Carrera.")]
        public int CarreraId { get; set; }

        [Required(ErrorMessage = "El campo Titulo de Proyecto es obligatorio.")]
        [MinLength(50, ErrorMessage = "El campo Titulo de Proyecto debe tener al menos 50 carácteres.")]
        public string TituloPropuesto { get; set; } = null!;
    }
}

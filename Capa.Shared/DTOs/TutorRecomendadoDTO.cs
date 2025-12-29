using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Shared.DTOs
{
    public class TutorRecomendadoDTO
    {
        public string NombreDocente { get; set; } = null!;
        public int PuntajeAfinidad { get; set; }
        public string Justificacion { get; set; } = null!;
    }
}

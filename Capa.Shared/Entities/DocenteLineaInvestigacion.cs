using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Shared.Entities
{
    public class DocenteLineaInvestigacion
    {
        public int DocenteId { get; set; }
        public Docente Docente { get; set; } = null!;

        public int LineaInvestigacionId { get; set; }
        public LineaInvestigacion LineaInvestigacion { get; set; } = null!;
    }
}

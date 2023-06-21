using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaF2X.Dtos.Response
{
    public class ReporteResponse
    {
        public string estacion { get; set; }
        public DateTime fecha { get; set; }
        public int totalcantidad { get; set; }
        public long totalvalores { get; set; }
    }
}

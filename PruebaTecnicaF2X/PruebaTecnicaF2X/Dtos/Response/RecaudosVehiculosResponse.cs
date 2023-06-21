using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaF2X.Dtos.Response
{
    public class RecaudosVehiculosResponse
    {
        public string estacion { get; set; }
        public string sentido { get; set; }
        public int hora { get; set; }
        public string categoria { get; set; }
        public long valorTabulado { get; set; }
        public DateTime fecha { get; set; }
    }
}

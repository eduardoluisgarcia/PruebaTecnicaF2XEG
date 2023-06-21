using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaF2X.Models
{
    public class RecaudosEntity
    {
        public string estacion { get; set; }
        public string sentido { get; set; }
        public int hora { get; set; }
        public string categoria { get; set; }
        public int cantidad { get; set; }
        public long valortabulado { get; set; }
        public DateTime fecha { get; set; }

    }
}

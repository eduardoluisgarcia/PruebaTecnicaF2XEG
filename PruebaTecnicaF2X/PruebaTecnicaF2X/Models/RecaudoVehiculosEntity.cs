using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaF2X.Models
{
    [Table(name: "recaudovehiculos")]
    public class RecaudoVehiculosEntity
    {
        [Key]
        public int id { get; set; }        
        public string estacion { get; set; }
        public string sentido { get; set; }
        public int hora { get; set; }
        public string categoria { get; set; }
        public long valorTabulado { get; set; }
        public DateTime fecha { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaF2X.Models
{
    [Table(name: "conteovehiculos")]
    public class ConteoVehiculosEntity
    {
        [Key]
        public int id { get; set; }        
        public string estacion { get; set; }
        public string sentido { get; set; }
        public int hora { get; set; }
        public string categoria { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
    }
}

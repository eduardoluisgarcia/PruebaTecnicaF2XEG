using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaF2X.Dtos.Request
{
    public class DatosVehiculosRequest
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public DateTime fechaInsert { get; set; }
    }
}

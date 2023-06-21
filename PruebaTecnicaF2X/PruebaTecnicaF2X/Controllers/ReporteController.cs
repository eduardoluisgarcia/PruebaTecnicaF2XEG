using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Interfaces;

using PruebaTecnicaF2X.DBContexts;

namespace PruebaTecnicaF2X.Controllers
{
    [ApiController]
    [Route("/api/v1/reporte")]
    //[Authorize]
    public class ReporteController : Controller
    {
        public readonly IReporteService _serviceReporte;
        public readonly ApplicationDBContext _context;
        public ReporteController(IReporteService serviceReporte, ApplicationDBContext context)
        {
            _serviceReporte = serviceReporte;
            _context = context;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> reporte(DateTime fechaInicio, DateTime fechaFin)
        {
            var result = await _serviceReporte.Reporte(fechaInicio, fechaFin);

            if (result != null)
            {
                return Ok(new ApiResponse("La consulta del Reporte ha sido realizada correctamente.", result, 200));
            }
            else
            {
                return ValidationProblem("La consulta del Reporte no pudo realizarse correctamente.");
            }
        }

    }
}

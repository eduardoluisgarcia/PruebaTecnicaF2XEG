using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Dtos.Response;
using PruebaTecnicaF2X.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaF2X.Interfaces
{
    public interface IReporteRepository
    {
        Task<List<ReporteResponse>> Reporte(DateTime fechaInicio, DateTime fechaFin);
    }
}

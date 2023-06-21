using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaF2X.Interfaces
{
    public interface IReporteService
    {
        Task<List<ReporteResponse>> Reporte(DateTime fechaInicio, DateTime fechaFin);
    }
}

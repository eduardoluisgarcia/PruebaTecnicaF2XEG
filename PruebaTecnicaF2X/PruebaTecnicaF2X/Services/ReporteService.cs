using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Models;
using PruebaTecnicaF2X.Dtos.Response;
using AutoMapper;

namespace PruebaTecnicaF2X.Services
{
    public class ReporteService : IReporteService
    {
        public readonly IReporteRepository _repositoryReporte;
        public readonly IMapper _mapper;
        public ReporteService(IReporteRepository repositoryReporte, IMapper mapper)
        {
            _repositoryReporte = repositoryReporte;
            _mapper = mapper;
        }

        public async Task<List<ReporteResponse>> Reporte(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ReporteResponse> entity = await _repositoryReporte.Reporte(fechaInicio, fechaFin);
            return entity;
        }
    }
}

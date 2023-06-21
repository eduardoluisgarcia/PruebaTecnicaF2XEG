using Microsoft.EntityFrameworkCore;
using PruebaTecnicaF2X.DBContexts;
using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Dtos.Response;
using PruebaTecnicaF2X.Interfaces;
using PruebaTecnicaF2X.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaF2X.Repository
{
    public class ReporteRepository : IReporteRepository
    {
        public readonly ApplicationDBContext _context;

        public ReporteRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ReporteResponse>> Reporte(DateTime fechaInicio, DateTime fechaFin)
        {
            var query = this.GetQueryReporte(fechaInicio, fechaFin);

            return await query.ToListAsync();
        }

        private IQueryable<ReporteResponse> GetQueryReporte(DateTime fechaInicio, DateTime fechaFin) 
        {
            var query = from c in _context.ConteoVehiculos
                        join r in _context.RecaudoVehiculos on new { c.estacion, c.sentido, c.hora, c.categoria, c.fecha } equals new { r.estacion, r.sentido, r.hora, r.categoria, r.fecha }
                        where c.fecha >= fechaInicio && c.fecha <= fechaFin
                        group new { c, r } by new { c.estacion, r.fecha } into g
                        orderby g.Key.estacion, g.Key.fecha
                        select new ReporteResponse
                        {
                            estacion = g.Key.estacion,
                            fecha = g.Key.fecha,
                            totalcantidad = g.Sum(x => x.c.cantidad),
                            totalvalores = g.Sum(x => x.r.valorTabulado)
                        };

            return query;
        }

    }
}

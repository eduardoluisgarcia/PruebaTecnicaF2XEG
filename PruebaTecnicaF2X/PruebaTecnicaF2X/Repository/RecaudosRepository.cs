using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Interfaces;
using PruebaTecnicaF2X.Models;
using PruebaTecnicaF2X.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaF2X.Repository
{
    public class RecaudosRepository : IRecaudosRepository
    {
        public readonly ApplicationDBContext _context;

        public RecaudosRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<RecaudosEntity>> Recaudos(RecaudosRequest Request)
        {
            var query = from x in _context.Recaudos select x;

            if (Request.estacion != null)
            {
                query = query.Where(x => x.estacion == Request.estacion);
            }

            if (Request.sentido != null)
            {
                query = query.Where(x => x.sentido == Request.sentido);
            }

            if (Request.hora.HasValue)
            {
                query = query.Where(x => x.hora == Request.hora.Value);
            }

            if (Request.categoria != null)
            {
                query = query.Where(x => x.categoria == Request.categoria);
            }

            if (Request.fecha != DateTime.MinValue)
            {
                query = query.Where(x => x.fecha == Request.fecha);
            }

            return query.ToListAsync();
        }
    }
}

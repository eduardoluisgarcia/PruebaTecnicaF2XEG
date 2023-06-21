using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Models;
using PruebaTecnicaF2X.Dtos.Request;

namespace PruebaTecnicaF2X.Interfaces
{
    public interface IRecaudosRepository
    {
        Task<List<RecaudosEntity>> Recaudos(RecaudosRequest Request);
    }
}

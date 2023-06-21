using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Dtos.Response;
using PruebaTecnicaF2X.Dtos.Request;

namespace PruebaTecnicaF2X.Interfaces
{
    public interface IRecaudosService
    {
        Task<List<RecaudosResponse>> Recaudos(RecaudosRequest Request);
    }
}

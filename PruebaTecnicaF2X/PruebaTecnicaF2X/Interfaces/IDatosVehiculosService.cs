using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Dtos.Response;

namespace PruebaTecnicaF2X.Interfaces
{
    public interface IDatosVehiculosService
    {
        Task<DatosVehiculosResponse> apiLogin(DatosVehiculosRequest Request);
        Task<List<ConteoVehiculosResponse>> apiConteoVehiculos(string token, DateTime fechaInsertConteoVehiculos);
        Task<List<ConteoVehiculosResponse>> insertConteoVehiculos(List<ConteoVehiculosResponse> listConteoVehiculosResponse, DateTime fechaInsertConteoVehiculos);
        Task<List<RecaudosVehiculosResponse>> apiRecaudosVehiculos(string token, DateTime fechaInsertRecaudoVehiculos);
        Task<List<RecaudosVehiculosResponse>> insertRecaudosVehiculos(List<RecaudosVehiculosResponse> listRecaudoVehiculosResponse, DateTime fechaInsertRecaudoVehiculos);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Models;
using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Dtos.Response;

namespace PruebaTecnicaF2X.Interfaces
{
    public interface IDatosVehiculosRepository
    {
        Task<DatosVehiculosResponse> apiLogin(DatosVehiculosRequest Request);
        Task<List<ConteoVehiculosResponse>> apiConteoVehiculos(string token, DateTime fechaInsertConteoVehiculos);        
        Task<List<ConteoVehiculosEntity>> insertConteoVehiculos(List<ConteoVehiculosEntity> entityConteoVehiculos, DateTime fechaInsertConteoVehiculos);
        Task<List<RecaudosVehiculosResponse>> apiRecaudosVehiculos(string token, DateTime fechaInsertRecaudoVehiculos);
        Task<List<RecaudoVehiculosEntity>> insertRecaudosVehiculos(List<RecaudoVehiculosEntity> entityRecaudoVehiculos, DateTime fechaInsertRecaudoVehiculos);
    }
}

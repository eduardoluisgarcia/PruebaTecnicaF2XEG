using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Dtos.Response;
using PruebaTecnicaF2X.Interfaces;
using PruebaTecnicaF2X.Models;

namespace PruebaTecnicaF2X.Services
{
    public class DatosVehiculosService : IDatosVehiculosService
    {
        public readonly IDatosVehiculosRepository _repositoryDatosVehiculos;
        public readonly IMapper _mapper;

        public DatosVehiculosService(IDatosVehiculosRepository repositoryDatosVehiculos, IMapper mapper)
        {
            _repositoryDatosVehiculos = repositoryDatosVehiculos;
            _mapper = mapper;
        }

        public async Task<DatosVehiculosResponse> apiLogin(DatosVehiculosRequest Request)
        {
            DatosVehiculosResponse entity = await _repositoryDatosVehiculos.apiLogin(Request);
            return entity;
        }

        public async Task<List<ConteoVehiculosResponse>> apiConteoVehiculos(string token, DateTime fechaInsertConteoVehiculos)
        {
            List<ConteoVehiculosResponse> entity = await _repositoryDatosVehiculos.apiConteoVehiculos(token, fechaInsertConteoVehiculos);
            return entity;
        }

        public async Task<List<ConteoVehiculosResponse>> insertConteoVehiculos(List<ConteoVehiculosResponse> listConteoVehiculosResponse, DateTime fechaInsertConteoVehiculos)
        {
            List<ConteoVehiculosEntity> entity = _mapper.Map<List<ConteoVehiculosResponse>, List<ConteoVehiculosEntity>>(listConteoVehiculosResponse);
            entity = await _repositoryDatosVehiculos.insertConteoVehiculos(entity, fechaInsertConteoVehiculos);
            List<ConteoVehiculosResponse> dto = _mapper.Map<List<ConteoVehiculosEntity>, List<ConteoVehiculosResponse>>(entity);
            return dto;
        }

        public async Task<List<RecaudosVehiculosResponse>> apiRecaudosVehiculos(string token, DateTime fechaInsertRecaudoVehiculos)
        {
            List<RecaudosVehiculosResponse> entity = await _repositoryDatosVehiculos.apiRecaudosVehiculos(token, fechaInsertRecaudoVehiculos);
            return entity;
        }

        public async Task<List<RecaudosVehiculosResponse>> insertRecaudosVehiculos(List<RecaudosVehiculosResponse> listRecaudoVehiculosResponse, DateTime fechaInsertRecaudoVehiculos)
        {
            List<RecaudoVehiculosEntity> entity = _mapper.Map<List<RecaudosVehiculosResponse>, List<RecaudoVehiculosEntity>>(listRecaudoVehiculosResponse);
            entity = await _repositoryDatosVehiculos.insertRecaudosVehiculos(entity, fechaInsertRecaudoVehiculos);
            List<RecaudosVehiculosResponse> dto = _mapper.Map<List<RecaudoVehiculosEntity>, List<RecaudosVehiculosResponse>>(entity);
            return dto;
        }
    }
}

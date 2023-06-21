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
    public class RecaudosService : IRecaudosService
    {
        public readonly IRecaudosRepository _repositoryRecaudos;
        public readonly IMapper _mapper;

        public RecaudosService(IRecaudosRepository repositoryRecaudos, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryRecaudos = repositoryRecaudos;
        }
            
        public async Task<List<RecaudosResponse>> Recaudos(RecaudosRequest Request)
        {
            List<RecaudosEntity> entity = await _repositoryRecaudos.Recaudos(Request);
            List<RecaudosResponse> dto = _mapper.Map<List<RecaudosEntity>, List<RecaudosResponse>>(entity);
            return dto;
        }
    }
}

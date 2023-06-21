using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Dtos.Response;
using PruebaTecnicaF2X.Models;

namespace PruebaTecnicaF2X.Mappings
{
    public class RecaudosMappings : Profile
    {
        public RecaudosMappings()
        {
            CreateMap<RecaudosEntity, RecaudosResponse>();
            CreateMap<ConteoVehiculosResponse, ConteoVehiculosEntity>();
            CreateMap<ConteoVehiculosEntity, ConteoVehiculosResponse>();
            CreateMap<RecaudosVehiculosResponse, RecaudoVehiculosEntity>();
            CreateMap<RecaudoVehiculosEntity, RecaudosVehiculosResponse>();
            CreateMap<ReporteEntity, ReporteResponse>();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Dtos.Response;
using AutoWrapper.Wrappers;
using PruebaTecnicaF2X.Interfaces;

namespace PruebaTecnicaF2X.Controllers
{
    [ApiController]
    [Route("/api/v1/datosvehiculos")]
    //[Authorize]
    public class DatosVehiculosController : Controller
    {
        public readonly IDatosVehiculosService _serviceDatosVehiculos;
        DatosVehiculosResponse dtosApiLogin = new DatosVehiculosResponse();

        public DatosVehiculosController(IDatosVehiculosService serviceDatosVehiculos)
        {
            _serviceDatosVehiculos = serviceDatosVehiculos;
        }

        [HttpPost("conteo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> apiLogin([FromQuery] DatosVehiculosRequest Request)
        {
            //Ejecutamos la Petición login 
            var resultApiLogin = await _serviceDatosVehiculos.apiLogin(Request);

            if (resultApiLogin != null)
            {
                //Consultamos el API con el token del Login 
                var resultApiConteoVehiculos = await _serviceDatosVehiculos.apiConteoVehiculos(resultApiLogin.token, Request.fechaInsert);

                if (resultApiConteoVehiculos != null)
                {
                    //Realizamos el insert en la tabla ConteoVehiculos
                    var resultInsertConteoVehiculos = await _serviceDatosVehiculos.insertConteoVehiculos(resultApiConteoVehiculos, Request.fechaInsert);

                    if (resultInsertConteoVehiculos != null)
                    {
                        return Ok(new ApiResponse("La consulta del conteo de vehiculos ha sido realizada correctamente.", resultInsertConteoVehiculos, 200));
                    }
                    else {
                        return ValidationProblem("El insert del conteo de vehiculos no pudo realizarse correctamente.");
                    }                    
                }
                else {
                    return ValidationProblem("La consulta de apiLogin no pudo realizarse correctamente.");
                }                
            }
            else
            {
                return ValidationProblem("La consulta de apiLogin no pudo realizarse correctamente.");
            }

        }

        [HttpPost("recaudo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> apiLoginRecaudos([FromQuery] DatosVehiculosRequest Request)
        {
            //Ejecutamos la Petición login 
            var resultApiLogin = await _serviceDatosVehiculos.apiLogin(Request);

            if (resultApiLogin != null)
            {
                //Consultamos el API con el token del Login 
                var resultApiRecaudoVehiculos = await _serviceDatosVehiculos.apiRecaudosVehiculos(resultApiLogin.token, Request.fechaInsert);

                if (resultApiRecaudoVehiculos != null)
                {
                    //Realizamos el insert en la tabla RecaudoVehiculos
                    var resultInsertRecaudoVehiculos = await _serviceDatosVehiculos.insertRecaudosVehiculos(resultApiRecaudoVehiculos, Request.fechaInsert);

                    if (resultInsertRecaudoVehiculos != null)
                    {
                        return Ok(new ApiResponse("La consulta de Recaudo de vehiculos ha sido realizada correctamente.", resultInsertRecaudoVehiculos, 200));
                    }
                    else
                    {
                        return ValidationProblem("El insert del Recaudo de vehiculos no pudo realizarse correctamente.");
                    }
                }
                else
                {
                    return ValidationProblem("La consulta del Recaudo de vehiculos no pudo realizarse correctamente.");
                }
            }
            else
            {
                return ValidationProblem("La consulta de apiLogin no pudo realizarse correctamente.");
            }

        }

    }
}

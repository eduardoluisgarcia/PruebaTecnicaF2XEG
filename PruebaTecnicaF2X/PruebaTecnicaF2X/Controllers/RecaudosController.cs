using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Interfaces;
using Microsoft.AspNetCore.Authorization;
using PruebaTecnicaF2X.Models;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaF2X.Helpers;

namespace PruebaTecnicaF2X.Controllers
{
    [ApiController]
    [Route("/api/v1/recaudos")]
    //[Authorize]
    public class RecaudosController : Controller
    {
        public readonly IRecaudosService _serviceRecaudos;
        private readonly IConfiguration conf;

        public RecaudosController(IRecaudosService Recaudos, IConfiguration config)
        {
            _serviceRecaudos = Recaudos;
            conf = config;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> recaudos([FromQuery] RecaudosRequest Request)
        {
            var result = await _serviceRecaudos.Recaudos(Request);

            if (result != null)
            {
                return Ok(new ApiResponse("La consulta de Recaudos ha sido realizada correctamente.", result, 200));
            }
            else
            {
                return ValidationProblem("La consulta de Recaudos no pudo realizarse correctamente.");
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<object> Login([FromBody] UsuariosEntity usuario)
        {
            string secret = this.conf.GetValue<string>("Secret");
            var jwtHelper = new JWTHelper(secret);
            var token = jwtHelper.CreateToken(usuario.Usuario);

            return Ok(new { ok = true, msg = "Usuario logeado con exito.", token });
        }
    }
}

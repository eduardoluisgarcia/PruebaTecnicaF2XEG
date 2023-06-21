using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Dtos.Request;
using PruebaTecnicaF2X.Interfaces;
using PruebaTecnicaF2X.Models;
using PruebaTecnicaF2X.DBContexts;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaF2X.Dtos.Response;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace PruebaTecnicaF2X.Repository
{
    public class DatosVehiculosRepository : IDatosVehiculosRepository
    {
        public readonly ApplicationDBContext _context;

        public DatosVehiculosRepository(ApplicationDBContext context)
        {
            _context = context;
        }       

        public async Task<DatosVehiculosResponse> apiLogin(DatosVehiculosRequest Request)
        {
            string parametersJson = JsonSerializer.Serialize(Request);

            using (HttpClient client = new HttpClient())
            {
                // Construir la solicitud de Login
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://23.102.103.53:5200/api/Login");
                request.Content = new StringContent(parametersJson, Encoding.UTF8, "application/json");

                // Enviar la solicitud y obtener la respuesta
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                // Leer el contenido de la respuesta
                string responseBody = await response.Content.ReadAsStringAsync();

                // Analizar el JSON de la respuesta para obtener el token
                var jsonResult = JsonDocument.Parse(responseBody);
                DatosVehiculosResponse datosVehiculosResponse = new DatosVehiculosResponse();

                datosVehiculosResponse.token = jsonResult.RootElement.GetString("token");
                datosVehiculosResponse.expiration = jsonResult.RootElement.GetString("expiration");
                
                return datosVehiculosResponse;
            }

        }

        public async Task<List<ConteoVehiculosResponse>> apiConteoVehiculos(string token, DateTime fechaInsertConteoVehiculos)
        {
            using (HttpClient client = new HttpClient())
            {
                string fechaFormateada = fechaInsertConteoVehiculos.ToString("yyyy-MM-dd");

                // Construir la solicitud de ConteoVehiculos
                string url = $"http://23.102.103.53:5200/api/ConteoVehiculos/{fechaFormateada}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", $"Bearer {token}");

                // Enviar la solicitud y obtener la respuesta
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                // Leer el contenido de la respuesta
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar el contenido en una lista de objetos ConteoVehiculosResponse
                List<ConteoVehiculosResponse> conteoVehiculosList = JsonSerializer.Deserialize<List<ConteoVehiculosResponse>>(responseBody);
                
                return conteoVehiculosList;
            }

        }

        public async Task<List<ConteoVehiculosEntity>> insertConteoVehiculos(List<ConteoVehiculosEntity> entityConteoVehiculos, DateTime fechaInsertConteoVehiculos)
        {
            List<ConteoVehiculosEntity> insertEntity = new List<ConteoVehiculosEntity>();

            foreach (var conteoVehiculo in entityConteoVehiculos)
            {
                ConteoVehiculosEntity entity = new ConteoVehiculosEntity
                {
                    estacion = conteoVehiculo.estacion,
                    sentido = conteoVehiculo.sentido,
                    hora = conteoVehiculo.hora,
                    categoria = conteoVehiculo.categoria,
                    cantidad = conteoVehiculo.cantidad,
                    fecha = fechaInsertConteoVehiculos
                };

                var result = await _context.ConteoVehiculos.AddAsync(entity);
                insertEntity.Add(result.Entity);
            }

            await _context.SaveChangesAsync();

            return insertEntity;
        }

        public async Task<List<RecaudosVehiculosResponse>> apiRecaudosVehiculos(string token, DateTime fechaInsertRecaudoVehiculos)
        {
            using (HttpClient client = new HttpClient())
            {
                string fechaFormateada = fechaInsertRecaudoVehiculos.ToString("yyyy-MM-dd");

                // Construir la solicitud de RecaudoVehiculos
                string url = $"http://23.102.103.53:5200/api/RecaudoVehiculos/{fechaFormateada}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", $"Bearer {token}");

                // Enviar la solicitud y obtener la respuesta
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                // Leer el contenido de la respuesta
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar el contenido en una lista de objetos RecaudoVehiculosResponse
                List<RecaudosVehiculosResponse> recaudoVehiculosList = JsonSerializer.Deserialize<List<RecaudosVehiculosResponse>>(responseBody);

                return recaudoVehiculosList;
            }
        }

        public async Task<List<RecaudoVehiculosEntity>> insertRecaudosVehiculos(List<RecaudoVehiculosEntity> entityRecaudoVehiculos, DateTime fechaInsertRecaudoVehiculos)
        {
            List<RecaudoVehiculosEntity> insertEntity = new List<RecaudoVehiculosEntity>();

            foreach (var recaudoVehiculo in entityRecaudoVehiculos)
            {
                RecaudoVehiculosEntity entity = new RecaudoVehiculosEntity
                {
                    estacion = recaudoVehiculo.estacion,
                    sentido = recaudoVehiculo.sentido,
                    hora = recaudoVehiculo.hora,
                    categoria = recaudoVehiculo.categoria,
                    valorTabulado = recaudoVehiculo.valorTabulado,
                    fecha = fechaInsertRecaudoVehiculos
                };

                var result = await _context.RecaudoVehiculos.AddAsync(entity);
                insertEntity.Add(result.Entity);
            }

            await _context.SaveChangesAsync();

            return insertEntity;
        }
    }
}

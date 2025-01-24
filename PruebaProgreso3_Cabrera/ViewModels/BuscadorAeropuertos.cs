using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using PruebaProgreso3_Cabrera.Models;
using PruebaProgreso3_Cabrera.Servicios;

namespace PruebaProgreso3_Cabrera.ViewModels
{

    public class BuscadorAeropuertos : BaseViewModel
    {
        private readonly BaseDeDatos _baseDeDatos;
        private readonly HttpClient cliente = new HttpClient();
        private string _consulta;
        public string Consulta { get => _consulta; set => AsignarPropiedad(ref _consulta, value); }

        private string _mensaje;
        public string Mensaje { get => _mensaje; set => AsignarPropiedad(ref _mensaje, value); }

        public Command ComandoBuscar { get; }
        public Command ComandoLimpiar { get; }

        public BuscadorAeropuertos(BaseDeDatos baseDeDatos)
        {
            _baseDeDatos = baseDeDatos;
            ComandoBuscar = new Command(async () => await BuscarAeropuertoAsync());
            ComandoLimpiar = new Command(() => { Consulta = string.Empty; Mensaje = string.Empty; });
        }

        private async Task BuscarAeropuertoAsync()
        {
            if (string.IsNullOrWhiteSpace(Consulta))
            {
                Mensaje = "Por favor, ingresa un país.";
                return;
            }

            try
            {
                var respuesta = await cliente.GetFromJsonAsync<List<Aeropuerto>>($"https://freetestapi.com/api/v1/airports?search={Consulta}&limit=1");
                if (respuesta == null || !respuesta.Any())
                {
                    Mensaje = "No se encontraron aeropuertos.";
                    return;
                }

                var aeropuerto = respuesta.First();
                await _baseDeDatos.GuardarAeropuertoAsync(aeropuerto);
                Mensaje = $"Aeropuerto encontrado: {aeropuerto.Nombre}";
            }
            catch (Exception ex)
            {
                Mensaje = $"Error: {ex.Message}";
            }
        }
    }
}


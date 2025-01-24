using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProgreso3_Cabrera.ViewModels
{
    public class BuscadorAeropuertos : BaseViewModel
    {
        private string _consulta;
        public string Consulta
        {
            get => _consulta;
            set => AsignarPropiedad(ref _consulta, value);
        }

        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
            set => AsignarPropiedad(ref _mensaje, value);
        }

        public Command ComandoBuscar { get; }
        public Command ComandoLimpiar { get; }

        public BuscadorAeropuertos()
        {
            ComandoBuscar = new Command(async () => await BuscarAeropuertoAsync());
            ComandoLimpiar = new Command(() => Consulta = string.Empty);
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
                using var cliente = new HttpClient();
                var respuesta = await cliente.GetFromJsonAsync<List<Aeropuerto>>(
                    $"https://freetestapi.com/api/v1/airports?search={Consulta}&limit=1");

                if (respuesta == null || !respuesta.Any())
                {
                    Mensaje = "No se encontraron aeropuertos.";
                    return;
                }

                var aeropuerto = respuesta.First();
                // Guardar en SQLite (se implementará más adelante)
                // await GuardarAeropuertoAsync(aeropuerto);

                Mensaje = $"Aeropuerto encontrado: {aeropuerto.Nombre}";
            }
            catch (Exception ex)
            {
                Mensaje = $"Error: {ex.Message}";
            }
        }
    }
}


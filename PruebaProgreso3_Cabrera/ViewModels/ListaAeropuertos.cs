using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProgreso3_Cabrera.ViewModels
{
    public class ListaAeropuertos : BaseViewModel
    {
        public ListaAeropuertos()
        {
            CargarAeropuertos();
        }
        private void CargarAeropuertos()
        {
            // Aquí se cargarían los aeropuertos desde SQLite (se implementará más adelante).
            // Ejemplo ficticio:
            Aeropuertos.Add(new Aeropuerto
            {
                Nombre = "Aeropuerto Changi de Singapur",
                Pais = "Singapur",
                Latitud = 1.3644,
                Longitud = 103.9915,
                Correo = "feedback@changiairport.com"
            });
        }

    }
}

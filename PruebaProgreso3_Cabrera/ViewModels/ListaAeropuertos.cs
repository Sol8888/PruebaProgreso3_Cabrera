using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PruebaProgreso3_Cabrera.Models;
using PruebaProgreso3_Cabrera.Servicios;


namespace PruebaProgreso3_Cabrera.ViewModels
{
    public class ListaAeropuertos : BaseViewModel
    {
        private readonly BaseDeDatos _baseDeDatos;
        public ObservableCollection<Aeropuerto> Aeropuertos { get; } = new ObservableCollection<Aeropuerto>();
        public ListaAeropuertos()
        {
            _baseDeDatos = baseDeDatos;
            CargarAeropuertos();
        }
        private void CargarAeropuertos()
        {
            var aeropuertos = await _baseDeDatos.ObtenerAeropuertosAsync();
            Aeropuertos.Clear();
            foreach (var aeropuerto in aeropuertos)
            {
                Aeropuertos.Add(aeropuerto);
            }
        }

    }
}

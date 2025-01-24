using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PruebaProgreso3_Cabrera.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace PruebaProgreso3_Cabrera.Servicios
{
    public class BaseDeDatos
    {

        private readonly SQLiteAsyncConnection _conexion;

        public BaseDeDatos()
        {
            try
            {
                var rutaDB = Path.Combine(FileSystem.AppDataDirectory, "scabrera_aeropuertos.db");
                _conexion = new SQLiteAsyncConnection(rutaDB);
                _conexion.CreateTableAsync<Aeropuerto>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inicializar la base de datos: {ex.Message}");
            }
        }

        
        public Task<int> GuardarAeropuertoAsync(Aeropuerto aeropuerto)
        {
            return _conexion.InsertAsync(aeropuerto);
        }

        
        public Task<List<Aeropuerto>> ObtenerAeropuertosAsync()
        {
            return _conexion.Table<Aeropuerto>().ToListAsync();
        }


    }
}

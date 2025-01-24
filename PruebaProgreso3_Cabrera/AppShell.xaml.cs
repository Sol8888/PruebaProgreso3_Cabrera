using PruebaProgreso3_Cabrera.Servicios;
using PruebaProgreso3_Cabrera.Views;
namespace PruebaProgreso3_Cabrera
{
    public partial class AppShell : Shell
    {
        private readonly BaseDeDatos _baseDeDatos;
        public AppShell(BaseDeDatos baseDeDatos)
        {
            InitializeComponent();
            _baseDeDatos = baseDeDatos;

            Routing.RegisterRoute(nameof(BuscadorAeropuertosPage), typeof(BuscadorAeropuertosPage));
            Routing.RegisterRoute(nameof(ListaAeropuertosPage), typeof(ListaAeropuertosPage));

            
            Items.Add(new ShellContent
            {
                Title = "Buscador",
                Content = new BuscadorAeropuertosPage(_baseDeDatos)
            });

            Items.Add(new ShellContent
            {
                Title = "Lista",
                Content = new ListaAeropuertosPage(_baseDeDatos)
            });
        }
    }
}

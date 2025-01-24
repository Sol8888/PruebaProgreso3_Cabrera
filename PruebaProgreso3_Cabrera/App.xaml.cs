using PruebaProgreso3_Cabrera.Servicios;
using PruebaProgreso3_Cabrera.Views;

namespace PruebaProgreso3_Cabrera
{
    public partial class App : Application
    {
        private readonly BaseDeDatos _baseDeDatos;
        public App()
        {
            InitializeComponent();
            _baseDeDatos = new BaseDeDatos(); 
            MainPage = new AppShell(_baseDeDatos); 
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell(_baseDeDatos));
        }
    }
}
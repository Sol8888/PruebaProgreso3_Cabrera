
using PruebaProgreso3_Cabrera.ViewModels;
using PruebaProgreso3_Cabrera.Servicios;

namespace PruebaProgreso3_Cabrera.Views;

public partial class BuscadorAeropuertosPage : ContentPage
{
	public BuscadorAeropuertosPage(BaseDeDatos baseDeDatos)
	{
		InitializeComponent();
        BindingContext = new BuscadorAeropuertos(baseDeDatos);
    }
}
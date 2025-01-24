
using PruebaProgreso3_Cabrera.ViewModels;
using PruebaProgreso3_Cabrera.Servicios;

namespace PruebaProgreso3_Cabrera.Views;

public partial class ListaAeropuertosPage : ContentPage
{
	public ListaAeropuertosPage(BaseDeDatos baseDeDatos)
	{
		InitializeComponent();

        BindingContext = new ListaAeropuertos(baseDeDatos);
    }
}
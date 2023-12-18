using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;


namespace AdopcionAnimalesAPP;

public partial class RegistroPage : ContentPage
{
    private Cliente _clientenuevo;

    private readonly ClienteService _ClienteService;
    public RegistroPage(ClienteService clienteService)
	{
		InitializeComponent();
        _ClienteService = clienteService;
        
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _clientenuevo = BindingContext as Cliente;
        if (_clientenuevo != null)
        {
            Cedula.Text = _clientenuevo.Cedula;
            Password.Text = _clientenuevo.Password;

        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Cliente cliente = new Cliente
        {
            Cedula = Cedula.Text,
            Nombre= Nombre.Text,
            Direccion=Direccion.Text,
            Password= Password.Text,
        };

        await _ClienteService.PostCliente(cliente);
        await Navigation.PopAsync();
    }

    private void Boton_Login(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }
}
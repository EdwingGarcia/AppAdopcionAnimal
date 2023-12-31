using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CommunityToolkit.Maui.Core;

namespace AdopcionAnimalesAPP;

public partial class LoginPage : ContentPage
{
	private Cliente _cliente;
    private string _cedula;
    private readonly ClienteService _ClienteService;

    public LoginPage()
	{

		InitializeComponent();
		_ClienteService = new ClienteService();
        _cliente = new Cliente();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Cedula.Text = "";
        Password.Text = "";
        if (_cliente != null && BindingContext is Cliente clienteBindingContext)
        {
            Cedula.Text = clienteBindingContext.Cedula;
            Password.Text = clienteBindingContext.Password;
        }
    }

    private async void Boton_Ingresar(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Cedula.Text) && !string.IsNullOrWhiteSpace(Password.Text))
        {
            _cliente.Cedula = Cedula.Text;
            _cliente.Password = Password.Text;

            Cliente usuario = await _ClienteService.GetCliente(_cliente.Cedula);

            if (usuario != null && usuario.Password == _cliente.Password)
            {
       

                Preferences.Set("Cedula",_cliente.Cedula);
                Preferences.Set("Password", _cliente.Password);
                Preferences.Set("Nombre", usuario.Nombre);
                await Navigation.PopAsync();
            }
        }
    }

    private void Boton_Registro(object sender, EventArgs e)
    {
       Navigation.PushAsync(new RegistroPage(_ClienteService));
    }
}

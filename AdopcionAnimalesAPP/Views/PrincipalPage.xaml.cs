using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;

namespace AdopcionAnimalesAPP;

public partial class PrincipalPage : ContentPage
{
    private Animal _animal;
    private readonly ApiService _ApiService;

    private string cedula;
    public PrincipalPage()
    {
        ApiService animalservice = new ApiService();

        InitializeComponent();
        _ApiService = animalservice;
        _animal = new Animal();

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        cedula = Preferences.Get("Cedula", "0");

        if (cedula != "0")
        {
            nombreBienvenida.Text = Preferences.Get("Nombre", "");
            btnAAdoptados.IsVisible = true;
            btnLog.Text = "Log Out";
            labelB.IsVisible = true;
            btnVet.IsVisible = true;
        }
        List<Animal> ListaAnimales = await _ApiService.Index();
        var animales = new ObservableCollection<Animal>(ListaAnimales);
        listaAnimales.ItemsSource = animales;
    }

    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        validarLogin();
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver animal", ToastDuration.Short, 14);

        await toast.Show();
        Animal? animal = e.SelectedItem as Animal;
        if (!cedula.Equals("0"))
        {
            await Navigation.PushAsync(new DetallesAnimalPage()
            {
                BindingContext = animal,
            });
        }
    }

    private async void MostrarAdoptados(object sender, EventArgs e)
    {
        validarLogin();
        if (!cedula.Equals("0"))
        {
            await Navigation.PushAsync(new AnimalesAdoptadosPage());
        }
    }


    private async void logs(object sender, EventArgs e)
    {
        validarLogin();
        if (!cedula.Equals("0"))
        {
            Preferences.Set("Cedula", "0");
            Preferences.Set("Password", "0");
            await Navigation.PushAsync(new PrincipalPage());
        }
    }

    private async void validarLogin()
    {
        if (Preferences.Get("Cedula", "0").Equals("0"))
        { //si no se encuentra en preferencias una cedula, se manda al login.
            await Navigation.PushAsync(new LoginPage());
        }
    }

    private async void MostrarVeterinario(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VeterinariasPage());

    }
}
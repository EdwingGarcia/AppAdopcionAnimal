using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;

namespace AdopcionAnimalesAPP;

public partial class AnimalesAdoptadosPage : ContentPage
{
    private Animal _animal;
    private string _cedula;
    private readonly AnimalService _AnimalService;
    public AnimalesAdoptadosPage(AnimalService animalservice, string cedulaCliente)
	{
		InitializeComponent();
        _AnimalService = animalservice;
        _animal = new Animal();
        _cedula = cedulaCliente;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Animal> ListaAnimales = await _AnimalService.BuscarPorPropietario(_cedula);
            ObservableCollection<Animal> animales = new ObservableCollection<Animal>(ListaAnimales);
            listaadoptados.ItemsSource = animales;
    }
    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver animal", ToastDuration.Short, 14);

        await toast.Show();
        Animal? animal = e.SelectedItem as Animal;
        await Navigation.PushAsync(new DetallesAnimalPage(_AnimalService, _cedula)
        {
            BindingContext = animal,
        });
    }
}
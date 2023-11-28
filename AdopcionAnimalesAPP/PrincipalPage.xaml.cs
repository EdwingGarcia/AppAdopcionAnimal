using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;

namespace AdopcionAnimalesAPP;

public partial class PrincipalPage : ContentPage
{
    private Animal _animal;
   
    private readonly AnimalService _AnimalService;
    public PrincipalPage(AnimalService animalservice)
	{
		InitializeComponent();
        _AnimalService = animalservice;
        _animal = new Animal();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Animal> ListaAnimales = await _AnimalService.GetAllAnimales();
        var animales = new ObservableCollection<Animal>(ListaAnimales);
        listaAnimales.ItemsSource = animales;
    }

    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver animal", ToastDuration.Short, 14);

        await toast.Show();
        Animal? animal = e.SelectedItem as Animal;
       
        await Navigation.PushAsync(new DetallesAnimalPage(_AnimalService)
        {
            BindingContext = animal,
        });
    }
}
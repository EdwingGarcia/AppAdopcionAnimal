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
        List<Animal> listaProp = await _AnimalService.BuscarPorPropietario(_cedula);
        List<Animal> listaFiltrada = listaProp.Where(animal => animal.Status == 1).ToList();
        ObservableCollection<Animal> animalesP = new ObservableCollection<Animal>(listaFiltrada);
        if (animalesP.Count == 0) { txtnoSolicitud.IsVisible = true; }
        listastatus.ItemsSource=animalesP;
        


       
        List<Animal> listaFiltrada2 = listaProp.Where(animal => animal.Status == 2).ToList();
        ObservableCollection<Animal> s = new ObservableCollection<Animal>(listaFiltrada2);
        if (s.Count == 0) { txtnoAnimales.IsVisible = true; }
        listaadoptados.ItemsSource = s;
        
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
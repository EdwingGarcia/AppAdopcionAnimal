using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using System.Collections.ObjectModel;

namespace AdopcionAnimalesAPP;

public partial class VeterinariasPage : ContentPage
{

	private Veterinario _veterinario;
    private readonly VeterinarioService _veterinarioService;

    public VeterinariasPage()
    {
       
        VeterinarioService veterinarioservice = new VeterinarioService();
        _veterinarioService = veterinarioservice;
        InitializeComponent();

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Veterinario> ListaVeterinario = await _veterinarioService.GetAllVeterinarios();
        var veterinarios = new ObservableCollection<Veterinario>(ListaVeterinario);
        listaVet.ItemsSource = veterinarios;
    }

    private async void ClickImg(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
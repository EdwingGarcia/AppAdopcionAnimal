using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using AdopcionAnimalesAPP.ViewModels;

namespace AdopcionAnimalesAPP;

public partial class DetallesAnimalPage : ContentPage
{
    private Animal _animal;
    private string _cedulaCliente;
    private readonly ApiService _apiService;

    public DetallesAnimalPage(Animal animal)
    {
        _animal = animal;
        InitializeComponent();
        BindingContext = new DetallesAnimalViewModel(_animal);
      

    }

    
}
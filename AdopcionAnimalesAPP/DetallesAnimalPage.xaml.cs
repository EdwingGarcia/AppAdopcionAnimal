using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;

namespace AdopcionAnimalesAPP;

public partial class DetallesAnimalPage : ContentPage
{
	private Animal _animal;
    private string _cedulaCliente;
	private readonly AnimalService _animalService;

	public DetallesAnimalPage(AnimalService animalservice,string cedulaCliente)
	{
		InitializeComponent();
		_animalService = animalservice;
        _cedulaCliente = cedulaCliente;
        
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _animal = BindingContext as Animal;
        Img.Source = _animal.Img;
        Nombre.Text = _animal.Nombre;
        nombreCientifico.Text = _animal.NombreCientifico;
        paisOrigen.Text = _animal.PaisOrigen;
        altura.Text = _animal.Altura.ToString();
        peso.Text = _animal.Peso.ToString();
        enfermedad.Text = _animal.Enfermedad;
        if(_animal.Status==1 || _animal.Status == 2)
        {
            btnSoli.IsVisible = false;
        }
    }

    private async void OnClickAdoptar(object sender, EventArgs e)
    {
        _animal.Status = 1;
        _animal.Propietario = _cedulaCliente;
        Img.Source = _animal.Img;
        Nombre.Text = _animal.Nombre;
        nombreCientifico.Text = _animal.NombreCientifico;
        paisOrigen.Text = _animal.PaisOrigen;
        altura.Text = _animal.Altura.ToString();
        peso.Text = _animal.Peso.ToString();
        enfermedad.Text = _animal.Enfermedad;
        
        await _animalService.UpdateAnimal(_animal.Id, _animal);
        await Navigation.PopAsync();
    }
}
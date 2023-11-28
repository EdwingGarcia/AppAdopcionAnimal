using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;

namespace AdopcionAnimalesAPP;

public partial class DetallesAnimalPage : ContentPage
{
	private Animal _animal;
	private readonly AnimalService _animalService;
	public DetallesAnimalPage(AnimalService animalservice)
	{
		InitializeComponent();
		_animalService = animalservice;
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
    }

    private void OnClickAdoptar(object sender, EventArgs e)
    {


    }
}
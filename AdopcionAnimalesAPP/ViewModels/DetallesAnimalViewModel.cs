using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;


namespace AdopcionAnimalesAPP.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DetallesAnimalViewModel
    {
        private readonly ApiService _apiService;
        private Animal _animal;
        private string _cedulaCliente;

        public bool VisibleBtnSoli { get; set; }
        public string ImgSource { get; set; }
        public string NombreText { get; set; }
        public string NombreCientificoText { get; set; }
        public string PaisOrigenText { get; set; }
        public string AlturaText { get; set; }
        public string PesoText { get; set; }
        public string EnfermedadText { get; set; }
        public ICommand Adoptar => new Command(async () => await OnClickAdoptar());

        public DetallesAnimalViewModel(Animal animal)
        {
            _cedulaCliente = Preferences.Get("Cedula", "0");
            _apiService = new ApiService();
            _animal = animal;

          //  buscarAnimal();

            if (_animal.Status == 1 || _animal.Status == 2)
            {
                VisibleBtnSoli = false;
            }
            else
            {
                VisibleBtnSoli = true;
            }
            ImgSource = _animal.Img;
            NombreText = _animal.Nombre;
            NombreCientificoText = _animal.NombreCientifico;
            PaisOrigenText = _animal.PaisOrigen;
            AlturaText = _animal.Altura.ToString();
            PesoText = _animal.Peso.ToString();
            EnfermedadText = _animal.Enfermedad;
        }

        private async Task OnClickAdoptar()
        {
            _animal.Status = 1;
            _animal.Propietario = _cedulaCliente;

            ImgSource = _animal.Img;
            NombreText = _animal.Nombre;
            NombreCientificoText = _animal.NombreCientifico;
            PaisOrigenText = _animal.PaisOrigen;
            AlturaText = _animal.Altura.ToString();
            PesoText = _animal.Peso.ToString();
            EnfermedadText = _animal.Enfermedad;

            await _apiService.UpdateAnimal(_animal.Id, _animal);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task buscarAnimal()
        {
            int ident = int.Parse(Preferences.Get("identificador", "0"));
            _animal = await _apiService.GetAnimal(ident);
        }

        public ICommand Volver => new Command(async () => await App.Current.MainPage.Navigation.PopAsync());
    }
}

using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using CommunityToolkit.Maui.Core;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdopcionAnimalesAPP.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PrincipalViewModel
    {
        
        private readonly string _cedula;
        private ApiService _apiService;
        public string Nombre { get; set; }
        public Boolean btnAAdoptados { get; set; }
        public string btnLog { get; set; }
        public Boolean LabelB { get; set; }
        public Boolean btnVet { get; set; }
        public ObservableCollection<Animal> animals { get; set; }
        public ICommand OpenAdoptados => new Command(async () => await MostrarAdoptados());
        public ICommand LogsCommand => new Command(async () => await Logs());
        public ICommand OpenDetalles => new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new DetallesAnimalPage()));
        public ICommand OpenVeterinarias => new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new VeterinariasPage()));

        public PrincipalViewModel() {
            _apiService = new ApiService();
            _cedula= Preferences.Get("Cedula", "0");
            Cargar();
           

        }


        public async void Cargar()
        {
            if (_cedula != "0")
            {
                Nombre = Preferences.Get("Nombre", "");
                btnAAdoptados = true;
                btnLog = "Log Out";
                LabelB = true;
                btnVet = true;
            }
            else
            {
                btnAAdoptados = false;
                btnLog = "Log In";
                LabelB = false;
                btnVet = false;
            }
            List<Animal> ListaAnimales = await _apiService.Index();
             animals = new ObservableCollection<Animal>(ListaAnimales);
        }


        private async Task ValidarLogin()
        {
            if (_cedula.Equals("0"))
            {
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else
            {
                Cargar();
            }
        }

        

        private async Task MostrarAdoptados()
        {
            ValidarLogin();
            if (!_cedula.Equals("0"))
            {
                await App.Current.MainPage.Navigation.PushAsync(new AnimalesAdoptadosPage());
            }
        }

        private async Task Logs()
        {
            ValidarLogin();
            if (!_cedula.Equals("0"))
            {
                Preferences.Set("Cedula", "0");
                Preferences.Set("Password", "0");
                await App.Current.MainPage.Navigation.PushAsync(new PrincipalPage());
                
            }

        }






     
    }
}

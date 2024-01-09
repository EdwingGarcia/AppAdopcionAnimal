using AdopcionAnimalesAPP.Service;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using AdopcionAnimalesAPP.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AdopcionAnimalesAPP.ViewModels
{
   
  
    [AddINotifyPropertyChangedInterface]
    public class AnimalesAdoptadosViewModel
    {
        private readonly string _cedula;
        private  ApiService _apiService;

        public ObservableCollection<Animal> AnimalesP { get; set; }
        public ObservableCollection<Animal> AnimalesS { get; set; }
        public Boolean mostrarTextoPendiente {  get; set; }
        public Boolean NoAnimal {  get; set; }

        public AnimalesAdoptadosViewModel()
        {
            _cedula = Preferences.Get("Cedula", "0");
           _apiService = new ApiService();
            Cargar();
        }

        public async void Cargar()
        {
            Console.WriteLine(_cedula);
            List<Animal> listaProp = await _apiService.BuscarPorPropietario(_cedula);
            List<Animal> listaFiltradaP = listaProp.Where(animal => animal.Status == 1).ToList();
            List<Animal> listaFiltradaS = listaProp.Where(animal => animal.Status == 2).ToList();
            AnimalesP = new ObservableCollection<Animal>(listaFiltradaP); //pendientes
            AnimalesS = new ObservableCollection<Animal>(listaFiltradaS); //adoptados
            if (AnimalesP.Count != 0) { mostrarTextoPendiente = true; } else { mostrarTextoPendiente = false; }// si hay animales pendientes
            if (AnimalesS.Count == 0) { NoAnimal = true; } else { NoAnimal = false; }//si no hay animales adoptados

        }
        public ICommand Volver => new Command(async () => await App.Current.MainPage.Navigation.PopAsync());

    }

    
    
}

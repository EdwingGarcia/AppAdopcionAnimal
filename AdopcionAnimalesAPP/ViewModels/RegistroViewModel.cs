using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdopcionAnimalesAPP.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class RegistroViewModel
    {
        private readonly ApiService _ApiService;
        private Cliente _clientenuevo;
        public string CedulaText { get; set; }
        public string PasswordText { get; set; }
        public string DireccionText { get; set; }
        public string NombreText { get; set; }
        public ICommand RegistroCompletado => new Command(async () => await Button_Clicked());
        public ICommand Login => new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new LoginPage()));
        public RegistroViewModel() {
            _ApiService = new ApiService();
            _clientenuevo = new Cliente();
            CedulaText = _clientenuevo.Cedula;
            PasswordText = _clientenuevo.Password;
        }

        private async Task Button_Clicked()
        {
            Cliente cliente = new Cliente
            {
                Cedula = CedulaText,
                Nombre = NombreText,
                Direccion = DireccionText,
                Password = PasswordText,
            };

            await _ApiService.PostCliente(cliente);
            await App.Current.MainPage.Navigation.PopAsync();
        }


    }
}

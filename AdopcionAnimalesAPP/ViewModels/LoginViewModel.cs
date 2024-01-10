using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
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
    public class LoginViewModel
    {

        private Cliente _cliente;
        private ApiService _ApiService;
        public string CedulaText {  get; set; }
        public string PasswordText { get; set; }

        public ICommand Ingresar => new Command(async () => await Boton_Ingresar());
        public ICommand Registro => new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new RegistroPage()));




        public LoginViewModel() {
            _ApiService = new ApiService();
            _cliente = new Cliente();
            CedulaText = "";
            PasswordText = "";
        }

   

        private async Task Boton_Ingresar()
        {
            if (!string.IsNullOrWhiteSpace(CedulaText) && !string.IsNullOrWhiteSpace(PasswordText))
            {
                _cliente.Cedula = CedulaText;
                _cliente.Password = PasswordText;

                Cliente usuario = await _ApiService.GetCliente(_cliente.Cedula);

                if (usuario != null && usuario.Password == _cliente.Password)
                {


                    Preferences.Set("Cedula", _cliente.Cedula);
                    Preferences.Set("Password", _cliente.Password);
                    Preferences.Set("Nombre", usuario.Nombre);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

    }

   


}

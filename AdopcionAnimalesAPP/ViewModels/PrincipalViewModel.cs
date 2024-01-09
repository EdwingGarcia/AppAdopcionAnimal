using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdopcionAnimalesAPP.ViewModels
{
    public class PrincipalViewModel
    {
       
      
       public ICommand OpenDetalles => new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new DetallesAnimalPage()));
       public ICommand OpenAdoptados => new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new AnimalesAdoptadosPage()));
        public ICommand OpenVeterinarias => new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new VeterinariasPage()));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdopcionAnimalesAPP.ViewModels
{
    public class DetallesAnimalViewModel
    {





        public ICommand Volver => new Command(async () => await App.Current.MainPage.Navigation.PopAsync());

    }
}

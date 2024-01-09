using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdopcionAnimalesAPP.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VeterinariasViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Veterinario> Veterinarios { get; set; }

        public VeterinariasViewModel()
        {
            _apiService = new ApiService();
            VetAsync();
        }

        private async void VetAsync()
        {
            var veterinariosList = await _apiService.GetAllVeterinarios();
            Veterinarios = new ObservableCollection<Veterinario>(veterinariosList);
        }

        public ICommand Volver => new Command(async () => await App.Current.MainPage.Navigation.PopAsync());



    }
}

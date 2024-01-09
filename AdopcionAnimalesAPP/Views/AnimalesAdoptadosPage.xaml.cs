using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using AdopcionAnimalesAPP.ViewModels;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;

namespace AdopcionAnimalesAPP;

public partial class AnimalesAdoptadosPage : ContentPage
{
    public AnimalesAdoptadosPage()
	{
		InitializeComponent();
        BindingContext = new AnimalesAdoptadosViewModel();

    }

   
    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        Animal? animal = e.SelectedItem as Animal;
        await Navigation.PushAsync(new DetallesAnimalPage( )
        {
            BindingContext = animal,
        });
    }

}
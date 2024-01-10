using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using AdopcionAnimalesAPP.ViewModels;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;

namespace AdopcionAnimalesAPP;

public partial class PrincipalPage : ContentPage
{

    public PrincipalPage()
    {
        InitializeComponent();
        BindingContext = new PrincipalViewModel();

    }


    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
       
        Animal? animal = e.SelectedItem as Animal;
      //  Preferences.Set("identificador", animal.Id);
            await Navigation.PushAsync(new DetallesAnimalPage()
            {
                BindingContext = animal,
            });

    }



}
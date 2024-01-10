using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using AdopcionAnimalesAPP.ViewModels;


namespace AdopcionAnimalesAPP;

public partial class RegistroPage : ContentPage
{
   

    
    public RegistroPage()
	{
		InitializeComponent();
        BindingContext = new RegistroViewModel();
    }
}
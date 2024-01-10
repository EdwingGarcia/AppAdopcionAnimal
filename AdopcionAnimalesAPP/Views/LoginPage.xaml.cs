using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CommunityToolkit.Maui.Core;
using AdopcionAnimalesAPP.ViewModels;

namespace AdopcionAnimalesAPP;

public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
		InitializeComponent();
        BindingContext=new LoginViewModel();
    }
}

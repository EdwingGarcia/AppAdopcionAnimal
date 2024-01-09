using AdopcionAnimalesAPP.Models;
using AdopcionAnimalesAPP.Service;
using AdopcionAnimalesAPP.ViewModels;
using System.Collections.ObjectModel;

namespace AdopcionAnimalesAPP;

public partial class VeterinariasPage : ContentPage
{ 
    public VeterinariasPage()
    {
        InitializeComponent();
        BindingContext = new VeterinariasViewModel();
    }
}
using AdopcionAnimalesAPP.Service;

namespace AdopcionAnimalesAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new PrincipalPage());
        }
    }
}

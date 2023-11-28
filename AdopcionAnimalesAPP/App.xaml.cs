using AdopcionAnimalesAPP.Service;

namespace AdopcionAnimalesAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ClienteService clienteservice = new ClienteService();
            MainPage = new NavigationPage(new LoginPage(clienteservice));
        }
    }
}

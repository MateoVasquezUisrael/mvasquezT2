using Microsoft.Extensions.DependencyInjection;
using mvasquezT2.Views;

namespace mvasquezT2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new Login()));
        }
    }
}
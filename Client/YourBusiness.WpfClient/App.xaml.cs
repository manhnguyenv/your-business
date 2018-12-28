using CommonServiceLocator;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using YourBusiness.WpfClient.Views;

namespace YourBusiness.WpfClient
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationView>("NavigationView");
            containerRegistry.RegisterForNavigation<WelcomeView>("WelcomeView");
        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
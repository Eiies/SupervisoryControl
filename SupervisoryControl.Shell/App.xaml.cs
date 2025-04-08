using SupervisoryControl.Infrastructure.DependencyInjection;
using SupervisoryControl.Shell.Views;
using System.Windows;

namespace SupervisoryControl.Shell;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App {
    protected override Window CreateShell() {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry) {
        DependencyInjectionSetup.RegisterTypes(containerRegistry);
        DependencyInjectionSetup.RegisterMySQL(containerRegistry);
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) {
    }
}
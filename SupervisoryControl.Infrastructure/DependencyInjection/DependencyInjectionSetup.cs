using SupervisoryControl.Core.Interfaces;
using SupervisoryControl.Core.Services;
using SupervisoryControl.Infrastructure.Services;

namespace SupervisoryControl.Infrastructure.DependencyInjection;

public class DependencyInjectionSetup {
    public static void RegisterTypes(IContainerRegistry containerRegistry) {
        containerRegistry.Register<IMainService, MainService>();
    }

    public static void RegisterMySQL(IContainerRegistry containerRegistry) {
        containerRegistry.Register<IMySqlService, MySqlService>();
    }
}
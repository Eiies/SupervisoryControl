using SupervisoryControl.Core.Interfaces;
using SupervisoryControl.Core.Services;
using SupervisoryControl.Infrastructure.Services;

namespace SupervisoryControl.Infrastructure.DependencyInjection;

public static class DependencyInjectionSetup {
    public static void RegisterTypes(IContainerRegistry containerRegistry) {
        containerRegistry.Register<IMainService, MainService>();
    }

    public static void RegisterMySql(IContainerRegistry containerRegistry) {
        containerRegistry.Register<IMySqlService, MySqlService>();
    }

    public static void RegisterServices(IContainerRegistry containerRegistry){
        containerRegistry.Register<IUserService, UserService>();
    }
}
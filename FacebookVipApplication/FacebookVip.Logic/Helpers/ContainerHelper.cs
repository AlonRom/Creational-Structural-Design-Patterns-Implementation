using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using Unity;

namespace FacebookVip.Logic.Helpers
{
    public static class ContainerHelper
    {
        static ContainerHelper()
        {
            Container = new UnityContainer();
            //Singletone
            Container.RegisterType<ILoginService, LoginService>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container { get; }
    }
}

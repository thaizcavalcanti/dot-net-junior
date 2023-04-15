using LogicaNegocio.Interfaces;
using LogicaNegocio.Servicos;
using Model.Infraestrutura.Interfaces;
using Model.Infraestrutura.Repositories;
using Site.Controllers;
using Unity;

namespace Site
{
    public static class DependencyResolver2
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IClienteService, ClienteService>();

            container.RegisterType<IClienteRepository, ClienteRepository>();
        }
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }
    }
}
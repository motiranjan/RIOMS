using Ninject;
using RIOMS.Domain.Abstract;
using RIOMS.Domain.Concrete;
using System;
using System.Web.Mvc;
namespace RIOMS.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();

        }
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBinding()
        {
            ninjectKernel.Bind<IRIOMSRepository>().To<RIOMSRepository>();
        }
    }
}
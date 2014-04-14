using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SHGolfStore.Domain.Abstract;
using Moq;
using SHGolfStore.Domain.Entities;
using SHGolfStore.Domain.Concrete;

namespace SHGolfStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            Mock<IItemRepository> mock = new Mock<IItemRepository >();
            mock.Setup(m => m.Items).Returns(new List<Item>
            {
                new Item {ItemId =1, ItemName ="Trolley"},
                new Item {ItemId = 2, ItemName ="Golf Bag"},
                new Item {ItemId = 3, ItemName ="Golf Ball"}
            }.AsQueryable ());

            //ninjectKernel.Bind<IItemRepository>().ToConstant(mock.Object );
            ninjectKernel.Bind <IItemRepository>().To<EFItemRepository >();
        }
    }
}
using System;
using SimpleInjector;
using SimpleInjectorLibrary.Services;

namespace SimpleInjectorLibrary
{
    public class SimpleInjectorLibraryClass
    {
        public Container Container { get; set; }

        public SimpleInjectorLibraryClass()
        {
            Container = new Container();
        }

        public void SetupContainerRegistration()
        {
            Container.Register<INameService, NameService>();
        }

        public void VerifyTheContainer()
        {
            Container.Verify();
        }

    }
}

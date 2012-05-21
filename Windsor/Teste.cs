using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Windsor
{
    [TestClass]
    public class Teste
    {
        private WindsorContainer container;

        #region Initialize and CleanUp
        [TestInitialize]
        public void Initialize()
        {
            container = new WindsorContainer();
            container.Install(FromAssembly.This());
        }

        [TestCleanup]
        public void CleanUp()
        {
            container.Dispose();
        }
        #endregion

        [TestMethod]
        public void ResolucaoUnitaria()
        {
            var somadorDecimal = container.Resolve<ISomador>();
            var dois = somadorDecimal.UmMaisUm();

            Assert.AreEqual(2, dois);
        }

        [TestMethod]
        public void ResulucaoDeTodasInterfaces()
        {
            var somadorBinario = container.ResolveAll<ISomador>()[1];
            var dois = somadorBinario.UmMaisUm();

            Assert.AreEqual(10, dois);
        }

        [TestMethod]
        public void ResolucaoGenerica()
        {
            var generico = container.Resolve<IGenerico<SomadorBinario>>();
            var deQuemEuSou = generico.DeQuemEuSou();
            
            Assert.AreEqual("SomadorBinario", deQuemEuSou);
        }

        [TestMethod]
        public void ResolucaoGenerica2()
        {
            var generico = container.Resolve<IGenerico<SomadorDecimal>>();
            var deQuemEuSou = generico.DeQuemEuSou();

            Assert.AreEqual("SomadorDecimal", deQuemEuSou);
        }

        [TestMethod]
        public void ResolucaoPorConstrutor()
        {
            var generico = container.Resolve<ClasseDependenteDeISomador>();
            var umMaisUm = generico.ExecutaUmMaisUm();

            Assert.AreEqual("2", umMaisUm);
        }
    }
}
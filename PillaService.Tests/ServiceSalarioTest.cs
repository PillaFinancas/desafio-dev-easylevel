using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PillaService.Test
{
    [TestClass]
    public class ServiceSalarioTest
    {
        [TestMethod]
        public void TestarReajuste0a1999()
        {
            SalarioService service = new();

            Assert.IsNotNull(service.ReajusteSalario(1000));
        }

        [TestMethod]
        public void TestarReajuste2000a3999()
        {
            SalarioService service = new();

            Assert.IsNotNull(service.ReajusteSalario(3333));
        }

        [TestMethod]
        public void TestarReajuste4000a6999()
        {
            SalarioService service = new();

            Assert.IsNotNull(service.ReajusteSalario(5500));
        }

        [TestMethod]
        public void TestarReajusteMaior7000()
        {
            SalarioService service = new();

            Assert.IsNotNull(service.ReajusteSalario(7001));
        }
    }
}
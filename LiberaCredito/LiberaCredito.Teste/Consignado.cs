using LiberaCredito.Produto;
using NUnit.Framework;

namespace LiberaCredito.Teste
{

    [TestFixture]
    public class Consignado : TestBase
    {
        public Consignado() : base(Credito.GetInstance(Base.TipoCredito.Consignado))
        {

        }

        [SetUp]
        public void Setup() 
        {
            Assert.IsInstanceOf<CreditoConsignado>(cred);
        }
        

    }
}
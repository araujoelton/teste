using LiberaCredito.Produto;
using NUnit.Framework;

namespace LiberaCredito.Teste
{

    [TestFixture]
    public class Imobiliario : TestBase
    {
        public Imobiliario() : base(Credito.GetInstance(Base.TipoCredito.Imobiliario))
        {

        }

        [SetUp]
        public void Setup() 
        {
            Assert.IsInstanceOf<CreditoImobiliario>(cred);
        }
        

    }
}
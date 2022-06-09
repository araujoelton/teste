using LiberaCredito.Produto;
using NUnit.Framework;

namespace LiberaCredito.Teste
{

    [TestFixture]
    public class Direto : TestBase
    {
        public Direto() : base(Credito.GetInstance(Base.TipoCredito.Direto))
        {

        }

        [SetUp]
        public void Setup() 
        {
            Assert.IsInstanceOf<CreditoDireto>(cred);
        }
        

    }
}
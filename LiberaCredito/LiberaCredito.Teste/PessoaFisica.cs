using LiberaCredito.Produto;
using NUnit.Framework;

namespace LiberaCredito.Teste
{

    [TestFixture]
    public class PessoaFisica : TestBase
    {
        public PessoaFisica() : base(Credito.GetInstance(Base.TipoCredito.PessoaFisica)){}

        [SetUp]
        public void Setup() 
        {
            Assert.IsInstanceOf<CreditoPessoaFisica>(cred);
        }
        

    }
}
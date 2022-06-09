using LiberaCredito.Produto;
using NUnit.Framework;

namespace LiberaCredito.Teste
{

    [TestFixture]
    public class PessoaJuridica : TestBase
    {
        public PessoaJuridica() : base(Credito.GetInstance(Base.TipoCredito.PessoaJuridica)){}

        [SetUp]
        public void Setup() 
        {
            Assert.IsInstanceOf<CreditoPessoaJuridica>(cred);
            vencimento = vencimento.AddDays(15);
        }
        
        [Test]
        public void ValorMinimoCredito() => Assert.Catch(()=>cred.CalcularEmprestimo(new Solicitacao { DataPrimeiroVencimento = vencimento, QtdParcelas = 10, ValorCredito = 10000 }), Messages.ERR_PJ_VAL_MIN);

        [Test]
        public void DataMinimaVencimento() => Assert.Catch(() => cred.CalcularEmprestimo(new Solicitacao { DataPrimeiroVencimento = System.DateTime.Now, QtdParcelas = 10, ValorCredito = 15000 }), Messages.ERR_QTD_MIN_DIAS);
        
        [Test]
        public void DataMaximaVencimento() => Assert.Catch(() => cred.CalcularEmprestimo(new Solicitacao { DataPrimeiroVencimento = System.DateTime.Today.AddDays(41), QtdParcelas = 10, ValorCredito = 15000 }), Messages.ERR_QTD_MAX_DIAS);

    }
}
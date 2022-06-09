
using NUnit.Framework;

namespace LiberaCredito.Teste
{
    public abstract class TestBase
    {
        protected ICredito cred = null;
        protected System.DateTime vencimento = System.DateTime.Today;

        public TestBase(ICredito cred)
        {
            this.cred = cred;
        }

        [Test]
        public void QtdMinimaParcela() => Assert.Catch(() => cred.CalcularEmprestimo(new Solicitacao { DataPrimeiroVencimento = vencimento, QtdParcelas = 4, ValorCredito = 15000 }), string.Format(Messages.ERR_QTD_MIN_PARCELA, cred.ObterRegrasParcelas().Key));

        [Test]
        public void QtdMaximaParcela() => Assert.Catch(() => cred.CalcularEmprestimo(new Solicitacao { DataPrimeiroVencimento = vencimento, QtdParcelas = 73, ValorCredito = 15000 }), string.Format(Messages.ERR_QTD_MIN_PARCELA, cred.ObterRegrasParcelas().Key));


        [Test]
        public void ValorMaximoCredito() => Assert.Catch(() => cred.CalcularEmprestimo(new Solicitacao { DataPrimeiroVencimento = vencimento, QtdParcelas = 5, ValorCredito = 2000000 }), Messages.ERR_VAL_MAX_CREDITO);


        [Test]
        public void Calcular()
        {
            double valor = 50000;
            int parcelas = 10;
            var res = cred.CalcularEmprestimo(new Solicitacao { DataPrimeiroVencimento = vencimento, QtdParcelas = parcelas, ValorCredito = valor });
            Assert.IsTrue(res.Aprovado);

            double juros = parcelas * cred.ObterTaxa() * valor ;

            Assert.AreEqual(res.Juros, juros);
            Assert.AreEqual(res.ValorTotalComJuros, juros + valor);

        }

    }
}

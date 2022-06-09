
using System;

namespace LiberaCredito.Produto
{
    public class CreditoPessoaJuridica : Base
    {
        public override double ObterTaxa() => 0.05;
        public override void ValidarEmprestimo(Solicitacao solicitacao)
        {
            base.ValidarEmprestimo(solicitacao);
            if(solicitacao.ValorCredito < 15000)
            { throw new Exception(Messages.ERR_PJ_VAL_MIN); }

            if(solicitacao.DataPrimeiroVencimento < System.DateTime.Today.AddDays(15))
            {throw new Exception(Messages.ERR_QTD_MIN_DIAS);}

            if (solicitacao.DataPrimeiroVencimento > System.DateTime.Today.AddDays(40))
            { throw new Exception(Messages.ERR_QTD_MAX_DIAS); }

        }       

    }
}

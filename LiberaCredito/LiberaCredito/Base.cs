using System;
using System.Collections.Generic;

namespace LiberaCredito
{
    public abstract class Base : ICredito
    {
        public enum TipoCredito
        {
            Consignado,
            Direto,
            Imobiliario,
            PessoaFisica,
            PessoaJuridica
        }
        
        public virtual Resultado CalcularEmprestimo(Solicitacao solicitacao)
        {
            ValidarEmprestimo(solicitacao);
            var tx = ObterTaxa();
            var juros = tx * ((double)solicitacao.QtdParcelas) * solicitacao.ValorCredito;
            return new Resultado { Aprovado = true, Juros = juros, ValorTotalComJuros = solicitacao.ValorCredito + juros };
        }

        public abstract double ObterTaxa();
        public virtual KeyValuePair<decimal, decimal> ObterRegrasParcelas() => new KeyValuePair<decimal, decimal>(5, 72);
        public virtual void ValidarEmprestimo(Solicitacao solicitacao)
        {
            var parc = ObterRegrasParcelas();
            if (solicitacao.QtdParcelas < parc.Key)
            { throw new Exception(string.Format(Messages.ERR_QTD_MIN_PARCELA, parc.Key)); }

            if (solicitacao.QtdParcelas > parc.Value)
            { throw new Exception(string.Format(Messages.ERR_QTD_MAX_PARCELA, parc.Value)); }


            if(solicitacao.ValorCredito > 1000000)
            { throw new Exception(Messages.ERR_VAL_MAX_CREDITO); }
        }

    }
}

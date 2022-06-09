using LiberaCredito.Produto;
using System;
using System.Collections.Generic;
using System.Text;
using static LiberaCredito.Base;

namespace LiberaCredito
{
    public static class Credito
    {
        public static ICredito GetInstance(TipoCredito tipo)
        {
            switch (tipo)
            {
                case TipoCredito.Consignado:
                    return new CreditoConsignado();
                case TipoCredito.Direto:
                    return new CreditoDireto();
                case TipoCredito.Imobiliario:
                    return new CreditoImobiliario();
                case TipoCredito.PessoaFisica:
                    return new CreditoPessoaFisica();
                case TipoCredito.PessoaJuridica:
                    return new CreditoPessoaJuridica();
               
                default:
                    throw new Exception("Tipo inválido");
            }
        }

    }
}

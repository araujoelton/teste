using System;

namespace LiberaCredito
{
    public class Solicitacao
    {
        public DateTime DataPrimeiroVencimento { get; set; }
        public double ValorCredito { get; set; }
        public int QtdParcelas { get; set; }
    }
}

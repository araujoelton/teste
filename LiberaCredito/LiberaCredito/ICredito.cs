using System.Collections.Generic;

namespace LiberaCredito
{
    public interface ICredito
    {
        double ObterTaxa();
        Resultado CalcularEmprestimo(Solicitacao solicitacao);
        KeyValuePair<decimal, decimal> ObterRegrasParcelas();
    }
}

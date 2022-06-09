using System;

namespace LiberaCredito
{
    class Program
    {

        static void Menu() {
            var tipos = new Base.TipoCredito[] {
                Base.TipoCredito.Direto,
                Base.TipoCredito.Consignado,
                Base.TipoCredito.PessoaJuridica,
                Base.TipoCredito.PessoaFisica,
                Base.TipoCredito.Imobiliario
            };

            //// Display title as the C# console calculator app.
            var opt = 0;
            while (opt == 0)
            {
                Console.WriteLine("Informe (1) para Crédito Direto");
                Console.WriteLine("Informe (2) para Crédito Consignado");
                Console.WriteLine("Informe (3) para Crédito Pessoa Jurica");
                Console.WriteLine("Informe (4) para Crédito Pessoa Fisica");
                Console.WriteLine("Informe (5) para Crédito Imobiliario");

                int.TryParse(Console.ReadLine(), out opt);
                if (opt > 5)
                { opt = 0; }
            }
            Console.Clear();

            double valor = 0;
            while (valor == 0)
            {
                Console.WriteLine("Informe o valor do crédito");
                double.TryParse(Console.ReadLine(), out valor);

            }

            int parcelas = 0;
            while (parcelas == 0)
            {
                Console.WriteLine("Informe a quantidade de parcelas");
                int.TryParse(Console.ReadLine(), out parcelas);

            }

            double dias = 0;
            while (dias == 0)
            {
                Console.WriteLine("Informe em quantos dias deseja receber a primeira parcela");
                double.TryParse(Console.ReadLine(), out dias);
            }

            try
            {
                var res = Credito.GetInstance(tipos[opt - 1]).CalcularEmprestimo(new Solicitacao
                {
                    DataPrimeiroVencimento = System.DateTime.Today.AddDays(dias),
                    QtdParcelas = parcelas,
                    ValorCredito = valor
                });
                Console.WriteLine($"Emprestimo aprovado com valor total a pagar de ${res.ValorTotalComJuros}, sendo ${res.Juros} de juros");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            while(true)
            { Menu(); }

        }
    }
}

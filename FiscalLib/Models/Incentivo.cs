namespace FiscalLib.Models
{
    public class Incentivo : Indicador
    {

        public Incentivo(short codigo) : base(codigo)
        {
        }

        public Incentivo(short codigo, string descricao) : base(codigo, descricao)
        {
        }

        public Incentivo(decimal percentualIncentivo, string prazo, short codigo = 0) : base(codigo)
        {
            PercentualIncentivo = percentualIncentivo;
            Prazo = prazo;
        }

        public decimal PercentualIncentivo { get; set; }

        public string Prazo { get; set; }

    }
}
namespace FiscalLib.Models
{
    public class Item : Entidade
    {
        public Item(int numSequenciaItem, string codigo, string cfop, decimal baseCalc, decimal aliquota, decimal icms, short apuracao, short incentivo)
        {
            NumSequenciaItem = numSequenciaItem;
            Codigo = codigo;
            BaseCalc = baseCalc;
            Aliquota = aliquota;
            Icms = icms;
            Cfop = new Cfop(cfop);
            Apuracao = new Apuracao(apuracao);
            Incentivo = new Incentivo(incentivo);
        }

        public Item(string codigo, string descricao, string ncm, string unidade, decimal percentual, string prazo)
        {
            Codigo = codigo;
            Descricao = descricao;
            Unidade = unidade;
            Ncm = new Ncm(ncm);
            Incentivo = new Incentivo(percentual, prazo);
        }

        public int NumSequenciaItem { get; private set; }

        public string Codigo { get; private set; }

        public string Descricao { get; private set; }
        public string Unidade { get; private set; }

        public decimal ValorContabil { get; private set; }

        public decimal BaseCalc { get; private set; }

        public decimal Aliquota { get; private set; }

        public decimal Icms { get; private set; }
        public Ncm Ncm { get; private set; }

        public Cfop Cfop { get; private set; }

        public Apuracao Apuracao { get; private set; }

        public Incentivo Incentivo { get; private set; }

        public override string ToString() => this.Codigo;

    }
}
namespace FiscalLib.Models
{
    public class Operacao : Indicador
    {
        public Operacao(short codigo) : base(codigo)
        {
        }

        public Operacao(short codigo, string descricao) : base(codigo, descricao)
        {
        }
    }
}
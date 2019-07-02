using System;

namespace FiscalLib.Models
{
    public abstract class Indicador
    {
        public short Codigo { get; private set; }

        public string Descricao { get; private set; }

        protected Indicador(short codigo)
        {
            Codigo = codigo;
        }

        protected Indicador(short codigo, string descricao)
        {
            Validar(codigo);
            Codigo = codigo;
            Descricao = descricao;
        }

        private void Validar(short codigo)
        {
            if (codigo < 0)
            {
                throw new Exception(string.Format("o código {0} é inválido", codigo));
            }
        }

        public override string ToString() => this.Codigo.ToString();

    }
}
using System;

namespace FiscalLib.Models
{
    public class Cfop : Entidade
    {

        public Cfop(string codigo, string descricao)
        {
            Validar(codigo);
            this.Codigo = codigo;
            this.Descricao = descricao;

        }
        public Cfop(string codigo)
        {
            Validar(codigo);
            this.Codigo = codigo;
        }

        public string Codigo { get; private set; }
        public string Descricao { get; private set; }

        private void Validar(string codigo)
        {

            if (codigo.Length != 4)
            {
                throw new Exception(
                    string.Format("Código de CFOP {0} é Inválido", codigo));
            }
        }
    }
}
using System;

namespace FiscalLib.Models
{
    public class Ncm : Entidade
    {
        public Ncm(string codigo)
        {
            Validar(codigo);
            Codigo = codigo;
        }

        public Ncm(string codigo, string descricao)
        {
            Validar(codigo);
            Codigo = codigo;
            Descricao = descricao;
        }

        public string Codigo { get; private set; }
        public string Descricao { get; private set; }

        private void Validar(string codigo)
        {

            if (!string.IsNullOrEmpty(codigo) && codigo.Length != 8)
            {
                throw new Exception(string.Format("Código de NCM {0} é Inválido", codigo));
            }
        }
    }
}
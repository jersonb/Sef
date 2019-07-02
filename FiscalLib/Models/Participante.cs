using System;

namespace FiscalLib.Models
{
    public class Participante : Entidade
    {
        public Participante(string codigo)
        {
            Codigo = codigo;
        }

        public Participante(string codigo, string nome, string cnpj, string cpf, string uf, string inscEstadual, string codMunicipio, string inscMunicipal, string codSuframa)
        {
            Codigo = codigo;
            Nome = nome;
            Cnpj = cnpj;
            Cpf = cpf;
            Uf = uf;
            InscEstadual = inscEstadual;
            CodMunicipio = codMunicipio;
            InscMunicipal = inscMunicipal;
            CodSuframa = codSuframa;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(this.Codigo))
            {
                throw new Exception(string.Format("O código {0} é inválido para Participante", this.Codigo));
            }
            if (string.IsNullOrEmpty(this.Nome))
            {
                throw new Exception(string.Format("O nome {0} é inválido para Participante", this.Codigo));
            }
            if (string.IsNullOrEmpty(this.Cnpj)
                     && string.IsNullOrEmpty(this.Cpf))
            {
                throw new Exception(string.Format("Informe o CNPJ ou o CPF do Participante de código {0}", this.Codigo));
            }
            if (!string.IsNullOrEmpty(this.Cnpj)
                     && !string.IsNullOrEmpty(this.Cpf))
            {
                throw new Exception(string.Format("Informe o CNPJ ou o CPF do Participante de código {0}", this.Codigo));
            }
            if (string.IsNullOrEmpty(this.InscEstadual))
            {
                throw new Exception(string.Format("Informe a Incrição Estadual do Participante de código {0}", this.Codigo));
            }
            if (this.Uf.Length != 2)
            {
                throw new Exception(string.Format("A UF do participante de código {0} é inválida", this.Codigo));
            }


        }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Cpf { get; set; }

        public string Uf { get; set; }

        public string InscEstadual { get; set; }

        public string CodMunicipio { get; set; }

        public string InscMunicipal { get; set; }
        public string CodSuframa { get; set; }

        public override string ToString() => this.Codigo;
    }
}
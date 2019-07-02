using System;
using System.Collections.Generic;
using System.Linq;

namespace FiscalLib.Models
{
    public class NotaFiscal : Entidade
    {
        private readonly List<Item> _itens;

        public NotaFiscal(short operacao, short emissao, string participante, short modeloNf, string serie, string numero, DateTime dataEmissao)
        {
            Validar(serie, numero, dataEmissao);

            Operacao = new Operacao(operacao);
            Emissao = new Emissao(emissao);
            Participante = new Participante(participante);
            ModeloNf = new ModeloNf(modeloNf);
            Serie = serie;
            Numero = numero;
            DataEmissao = dataEmissao;
        }

        public Operacao Operacao { get; private set; }
        public Emissao Emissao { get; private set; }
        public Participante Participante { get; private set; }
        public ModeloNf ModeloNf { get; private set; }
        public string Serie { get; private set; }
        public string Numero { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public decimal VlContabil { get { return _itens.Sum(x => x.ValorContabil); } }
        public decimal VlBaseCalculo { get { return _itens.Sum(x => x.BaseCalc); } }
        public decimal VlIcms { get { return _itens.Sum(x => x.Icms); } }
        public IEnumerable<Item> Itens { get { return _itens.ToArray(); } }

        public void AddItem(Item item) => _itens.Add(item);

        private void Validar(string serie, string numero, DateTime dataEmissao)
        {
            if (string.IsNullOrEmpty(serie)
                || serie.Length > 3)
            {
                throw new Exception(string.Format("A Nota {0} não tem uma série válida", numero));
            }
            if (string.IsNullOrEmpty(numero)
                || numero.Length > 9)
            {
                throw new Exception(string.Format("O número desta nota não é válido: {0}", numero));
            }
            if (dataEmissao == null)
            {
                throw new Exception(string.Format("Esta data não é válida: {0}", dataEmissao));
            }

        }
    }
}
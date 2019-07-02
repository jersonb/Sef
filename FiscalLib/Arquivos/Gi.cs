using System;
using System.Collections.Generic;
using System.Linq;
using FiscalLib.Models;

namespace FiscalLib.Arquivos
{
    public class Gi : Arquivo
    {
        private readonly List<Participante> _participantes;
        private readonly List<Item> _itens;
        private readonly List<NotaFiscal> _notasFiscais;
        public Gi()
        {
        }

        private Gi(Participante empresa, List<Participante> participantes, List<Item> itens, List<NotaFiscal> notasFiscais)
        {
            _participantes = participantes;
            _itens = itens;
            _notasFiscais = notasFiscais;
            Empresa = empresa;
        }
        public DateTime Exercicio { get; private set; }

        public Participante Empresa { get; private set; }

        public IEnumerable<Participante> Participantes { get { return this._participantes.ToArray(); } }

        public IEnumerable<Item> Itens { get { return this._itens.ToArray(); } }

        public IEnumerable<NotaFiscal> NotasFiscais { get { return this._notasFiscais.ToArray(); } }


        public Gi Import(List<string> linhas)
        {
            if (linhas.Count == 0 || linhas == null)
            {
                throw new Exception("É necessário atribuir dados a propiedade Linhas");

            }

            this.Linhas = linhas;

            var gi = new Gi(SetEmpresa(), SetParticipantes(), SetItens(), SetNotasFiscais());

            return gi;
        }

        public Gi Import()
        {
            if (this.Linhas.Count == 0 || this.Linhas == null)
            {
                throw new Exception("É necessário atribuir dados a propiedade Linhas");

            }
            var gi = new Gi(SetEmpresa(), SetParticipantes(), SetItens(), SetNotasFiscais());

            return gi;
        }

        public List<string> Export()
        {
            var gi = new List<string>();

            var empresa = GetEmpresa();
            gi.Add(empresa);

            var participantes = GetParticipantes();
            gi.AddRange(participantes);

            var itens = GetItens();
            gi.AddRange(itens);

            var notasFiscais = GetNotasFiscais();
            gi.AddRange(notasFiscais);

            return gi;
        }

        private string GetEmpresa()
        {
            this.Empresa.Registro = "0000";

            var empresa = string.Join("|",
                                        "",
                                        this.Empresa.Registro,
                                        this.Empresa,
                                        this.Empresa.Cnpj,
                                        this.Empresa.Nome,
                                        this.Empresa.Uf,
                                        this.Empresa.InscEstadual,
                                        "");
            return empresa;
        }

        private Participante SetEmpresa()
        {
            var linha = this.Linhas.Where(x => x.Substring(0, 6)
                                                .Equals("|0000|"))
                                                .FirstOrDefault();

            var data = linha.Split('|');

            var empresa = new Participante(data[6],
                                            data[5],
                                            data[6],
                                            "",
                                            data[7],
                                            data[8],
                                            data[9],
                                            "",
                                            data[12]);

            return empresa;

        }

        private List<string> GetParticipantes()
        {
            var particiantes = new List<string>();

            this._participantes.ForEach(x => particiantes.Add(GetParticipante(x)));

            return particiantes;

        }

        private string GetParticipante(Participante p)
        {
            p.Registro = "0150";

            var participante = string.Join("|",
                                            "",
                                            p.Registro,
                                            p,
                                            p.Cnpj,
                                            p.Nome,
                                            p.Uf,
                                            p.InscEstadual,
                                            "");

            return participante;

        }

        private List<Participante> SetParticipantes()
        {
            var participantes = new List<Participante>();

            var linhas = this.Linhas.Where(x => x.Substring(0, 6)
                                                 .Equals("|0150|"))
                                                 .ToList();

            foreach (var linha in linhas)
            {
                var data = linha.Split('|');

                var participante = new Participante(data[2],
                                                    data[3],
                                                    data[5],
                                                    data[6],
                                                    data[8],
                                                    data[10],
                                                    data[11],
                                                    data[12],
                                                    data[13]);

                participantes.Add(participante);

            }

            return participantes;

        }

        private List<string> GetItens()
        {
            var itens = new List<string>();
            this._itens.ForEach(x => itens.Add(GetItem(x)));
            return itens;
        }

        private string GetItem(Item item)
        {
            item.Registro = "8525";

            return string.Join("|", "",
                                item.Registro,
                                item,
                                item.Descricao,
                                item.Ncm,
                                item.Unidade,
                                item.Incentivo.PercentualIncentivo,
                                item.Incentivo.Prazo,
                                "");
        }

        private string GetItem(IEnumerable<Item> list)
        {
            var itens = string.Empty;
            foreach (var item in list)
            {
                item.Registro = "8535";

                string.Join("|", "",
                                   item.Registro,
                                   item,
                                   item.ValorContabil,
                                   item.Cfop,
                                   item.BaseCalc,
                                   item.Aliquota,
                                   item.Icms,
                                   item.Apuracao,
                                   item.Incentivo,
                                   "");
                itens += item + "\n";
            }

            return itens;

        }

        private List<Item> SetItens()
        {
            var itens = new List<Item>();
            var linhas = this.Linhas.Where(x => x.Substring(0, 6)
                                                 .Equals("|8525|"))
                                                 .ToList();

            foreach (var linha in linhas)
            {
                var data = linha.Split('|');

                var item = new Item(data[2],
                                    data[3],
                                    data[4],
                                    data[5],
                                    decimal.Parse(data[6]),
                                    data[7]);

                itens.Add(item);

            }
            return itens;
        }

        private Item SetItem(string linha)
        {
            var data = linha.Split('|');
            var item = new Item(int.Parse(data[2]),
                                data[3],
                                data[4],
                                decimal.Parse(data[5]),
                                decimal.Parse(data[6]),
                                decimal.Parse(data[7]),
                                short.Parse(data[8]),
                                short.Parse(data[9]));

            return item;
        }

        private string GetNotaFiscal(NotaFiscal n)
        {
            n.Registro = "8530";
            var nota = string.Join("|", "",
                                        n.Registro,
                                       n.Operacao,
                                       n.Emissao,
                                       n.Participante,
                                       n.ModeloNf,
                                       n.Serie,
                                       n.Numero,
                                       n.DataEmissao.ToString("ddMMyyyy"),
                                       n.VlContabil,
                                       n.VlBaseCalculo,
                                       n.VlIcms, "");
            nota += GetItem(n.Itens);

            return nota;
        }

        private List<string> GetNotasFiscais()
        {
            var nfs = new List<string>();

            this._notasFiscais.ForEach(x => nfs.Add(GetNotaFiscal(x)));

            return nfs;
        }

        private NotaFiscal SetNotaFiscal(string linha)
        {
            var data = linha.Split('|');
            var nota = new NotaFiscal(short.Parse(data[2]),
                                      short.Parse(data[3]),
                                      data[4],
                                      short.Parse(data[5]),
                                      data[6],
                                      data[7],
                                      DateTime.Parse(data[8]));
            return nota;
        }

        private List<NotaFiscal> SetNotasFiscais()
        {
            var notasFiscais = new List<NotaFiscal>();
            NotaFiscal nf = null;

            var linhas = this.Linhas.Where(x => x.Substring(0, 6).Equals("|8530|")
                                                || x.Substring(0, 6).Equals("|8535|"))
                                                 .ToList();

            foreach (var linha in linhas)
            {
                if (linha.Substring(0, 6).Equals("|8530|"))
                {
                    if (nf != null)
                    {
                        notasFiscais.Add(nf);

                    }

                    nf = SetNotaFiscal(linha);

                }
                else
                {
                    var item = SetItem(linha);
                    nf.AddItem(item);


                }

            }
            notasFiscais.Add(nf);

            return notasFiscais;
        }




    }

}

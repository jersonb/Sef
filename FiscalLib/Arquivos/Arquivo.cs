using System.Collections.Generic;

namespace FiscalLib.Arquivos
{
    public abstract class Arquivo
    {
        public long Id { get; private set; }
        public TipoArquivo Tipo { get; set; }
        public List<string> Linhas { get; set; }
    }
    public enum TipoArquivo
    {
        EDOC, LA, GI
    }
}
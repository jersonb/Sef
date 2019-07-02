using FiscalLib.Arquivos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiscalLibTest
{
    [TestClass]
    public class FiscalTest
    {
        [TestMethod]
        public void TesteDeleituraDeArquivoGi()
        {
            var teste = new Gi();

            try
            {
                teste.Import();
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}

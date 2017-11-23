using System;
using System.Web.Configuration;

namespace FC_TestFramework.Core.APIs
{
    public class TestManager
    {
        private TestManager() { }

        private static string TFS = WebConfigurationManager.AppSettings["TFS"];
        private string NomeProjeto = WebConfigurationManager.AppSettings["Projeto"];

        private Uri UrlProjeto = new Uri(TFS);
        private string Versao = WebConfigurationManager.AppSettings["Versao"];
        private string CaminhoKanban = WebConfigurationManager.AppSettings["CaminhoKanban"];
        private string Ambiente = WebConfigurationManager.AppSettings["Ambiente"];

        public int NumeroTarefa { get; set; }

        /**Cria uma tarefa durante a inicialização da execução dos testes*/
        public virtual void CriarTarefa() { }

        /**Cria uma tarefa durante a inicialização da execução dos testes*/
        public virtual void CriarBugAssociado(String Descricao) { }
    }
}

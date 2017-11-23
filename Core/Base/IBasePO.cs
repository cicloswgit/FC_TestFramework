
using TechTalk.SpecFlow;

namespace FC_TestFramework.Core.Base
{
    interface IBasePO
    {
        #region Listar Atributos
        //declaracao dos elementos que serao manipulados no formulario da PO
        #endregion

        #region Realizar acoes

        //metodo que realiza navegacao no sistema para alcancar PO
        void SelecionarMenu(string Caminho);

        //metodo que identifica e preenche/seleciona elementos da PO
        void PreencherDadosFormulario(object Objeto);

        //metodo que realiza a acao cadastrar/salvar/enviar da PO
        void SubmeterFormulario();

        //metodo que valida o retorno da acao de submissao principal
        void ValidarRetorno();

        //metodo que gera objeto atraves de instancia de tabela ou Mocking
        void RecuperarObjeto(Table Table);
        #endregion
    }
}

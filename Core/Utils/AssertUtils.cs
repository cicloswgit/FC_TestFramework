using System;
using OpenQA.Selenium;
using NUnit.Framework;
using FC_TestFramework.Core.Setup;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace FC_TestFramework.Core.Utils
{
    public class AssertUtils : IManager
    {
        private ElementUtils Elemento;
        public AssertUtils(RemoteWebDriver Driver) : base (Driver) { Elemento = new ElementUtils(Driver); }


        /**Compara o valor da tag <head><title> do elemento atual com o resultado esperado*/
        public virtual void TituloIgual(String esperado)
        {
            try
            {
                Assert.AreEqual(esperado, Driver.Title);
            }
            catch (Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }
        }

        /**Compara texto do elemento atual com o resultado esperado*/
        public virtual void TextoIgual(String esperado, By seletor)
        {
            try
            {
                Assert.AreEqual(esperado, Elemento.PegarValorCampo(seletor));
            }
            catch (Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }
        }
        public virtual void TextoIgual(String esperado, String atual)
        {
            try
            {
                Assert.AreEqual(esperado, atual);
            }
            catch (Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }
        }

        /**Compara se texto do elemento atual difere do esperado*/
        public virtual void TextoDiferente(String esperado, By seletor)
        {
            try
            {
                Assert.AreNotEqual(esperado, Elemento.PegarValorCampo(seletor));
            }
            catch (Exception e)
            {
                new Exception("Os valores correspondem. Motivo: " + e.Message);
            }
        }
        public virtual void TextoDiferente(String esperado, String atual)
        {
            try
            {
                Assert.AreNotEqual(esperado, atual);
            }
            catch (Exception e)
            {
                new Exception("Os valores correspondem. Motivo: " + e.Message);
            }
        }
        

        /**Compara partes do texto do elemento atual com o resultado esperado, o identificando*/
        public virtual void TextoParcial(String esperado, By seletor)
        {
            try
            {
                StringAssert.Contains(esperado, Elemento.PegarValorCampo(seletor));
            }
            catch(Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }
        }
        public virtual void TextoParcial(String esperado, String atual)
        {
            try
            {
                StringAssert.Contains(esperado, atual);
            }
            catch (Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }
        }

        /**Compara o início do texto do elemento atual com o resultado esperado, o identificando*/
        public virtual void TextoInicial(String esperado, By seletor)
        {
            try
            {
                StringAssert.StartsWith(esperado, Elemento.PegarValorCampo(seletor));
            }
            catch (Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }

        }
        public virtual void TextoInicial(String esperado, String atual)
        {
            try
            {
                StringAssert.StartsWith(esperado, atual);
            }
            catch (Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }

        }

        /**Compara o final do texto do elemento atual com o resultado esperado, o identificando*/
        public virtual void TextoFinal(String esperado, By seletor)
        {
            try
            {
                StringAssert.EndsWith(esperado, Elemento.PegarValorCampo(seletor));
            }
            catch (Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }
        }
        public virtual void TextoFinal(String esperado, String atual)
        {
            try
            {
                StringAssert.EndsWith(esperado, atual);
            }
            catch (Exception e)
            {
                new Exception("Os valores não correspondem. Motivo: " + e.Message);
            }
        }

        /**Compara texto do elemento atual com o resultado esperado, o identificando, e 
         * segue para o próximo passo do teste, em caso negativo*/
        public virtual void TextoElemento(String esperado, By seletor)
        {
            try
            {
                Assert.AreEqual(esperado, Elemento.PegarValorCampo(seletor));
            }
            catch (Exception e)
            {
                Console.WriteLine("Os valores não correspondem. Motivo: " + e.Message);
            }
        }

        /**Verifica se a condição é verdadeira*/
        public virtual void CondicaoVerdadeira(Boolean operacao)
        {
            try
            {
                Assert.IsTrue(operacao, "O valor não é Verdadeiro.");
            }
            catch (Exception e)
            {
                new Exception("A condição não é verdadeira. Motivo: " + e.Message);
            }
        }
        public virtual void CondicaoVerdadeira(Boolean operacao, string mensagem)
        {
            try
            {
                Assert.IsTrue(operacao, mensagem);
            }
            catch (Exception e)
            {
                new Exception("A condição não é verdadeira. Motivo: " + e.Message);
            }
        }

        /**Verifica se a condição é falsa*/
        public virtual void CondicaoFalsa(Boolean operacao)
        {
            try
            {
                Assert.IsFalse(operacao, "O valor não é Falso.");
            }
            catch (Exception e)
            {
                new Exception("A condição não é falsa. Motivo: " + e.Message);
            }
        }

        public virtual void CondicaoFalsa(Boolean operacao, string mensagem)
        {
            try
            {
                Assert.IsFalse(operacao, mensagem);
            }
            catch (Exception e)
            {
                new Exception("A condição não é falsa. Motivo: " + e.Message);
            }
        }

        /**Aguarda a condição de apresentação de um alert*/
        public virtual bool ValidarAlert()
        {
            IAlert alert = null;
            try
            {
                alert = ExpectedConditions.AlertIsPresent().Invoke(Driver);
                
            }
            catch (Exception e)
            {
                new Exception("O alert não foi apresentado. Motivo " + e.Message);
            }
            return (alert != null);
        }
    }
}

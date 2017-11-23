using System;
using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using FC_TestFramework.Core.Setup;
using OpenQA.Selenium.Remote;

namespace FC_TestFramework.Core.Utils
{
    public class ElementUtils : IManager
    {

        public ElementUtils (RemoteWebDriver Driver) : base(Driver) { }


        #region Esperas

        /*Aguarda um tempo específico antes de realizar alguma ação do teste*/
        public void AguardarSegundos()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public virtual void AguardarSegundos(TimeSpan tempo)
        {
            Driver.Manage().Timeouts().ImplicitWait = tempo;
        }

        /*Aguarda o carregamento da página*/
        public void AguardarPaginaCarregar()
        {
            IJavaScriptExecutor JS = (IJavaScriptExecutor)Driver;
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            Wait.Until(wd => JS.ExecuteScript("return document.readyState").ToString() == "complete");
        }
        public virtual void AguardarPaginaCarregar(TimeSpan tempo)
        {
            IJavaScriptExecutor JS = (IJavaScriptExecutor)Driver;
            WebDriverWait Wait = new WebDriverWait(Driver, tempo);
            Wait.Until(wd => JS.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        /*Aguarda o carregamento de um determinado elemento na página*/
        public void AguardarElemento(By seletor)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(seletor));
            }
            catch (Exception e)
            {
                new Exception("O elemento não foi carregado na tela. Motivo: " + e.Message);
            }
        }
        public virtual void AguardarElemento(By seletor, TimeSpan tempo)
        {
            try
            {
                new WebDriverWait(Driver, tempo)
                    .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(seletor));
            }
            catch (Exception e)
            {
                new Exception("O elemento não foi carregado na tela. Motivo: " + e.Message);
            }
        }

        /*Aguarda a visibilidade de um determinado elemento na página*/
        public void AguardarVerElemento(By seletor)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.ElementIsVisible(seletor));
            }
            catch (Exception e)
            {
                new Exception("O elemento não foi apresentado na tela. Motivo: " + e.Message);
            }
        }
        public virtual void AguardarVerElemento(By seletor, TimeSpan tempo)
        {
            try
            {
                new WebDriverWait(Driver, tempo)
                    .Until(ExpectedConditions.ElementIsVisible(seletor));
            }
            catch (Exception e)
            {
                new Exception("O elemento não foi apresentado na tela. Motivo: " + e.Message);
            }
        }

        /*Aguarda o texto de um determinado elemento na página*/
        public void AguardarVerTexto(By seletor, String texto)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(50))
                    .Until(ExpectedConditions.TextToBePresentInElementLocated(seletor, texto));
            }
            catch (Exception e)
            {
                new Exception("O texto não foi apresentado na tela. Motivo: " + e.Message);
            }
        }
        public virtual void AguardarVerTexto(By seletor, String texto, TimeSpan tempo)
        {
            try
            {
                new WebDriverWait(Driver, tempo)
                    .Until(ExpectedConditions.TextToBePresentInElementLocated(seletor, texto));
            }
            catch (Exception e)
            {
                new Exception("O texto não foi apresentado na tela. Motivo: " + e.Message);
            }
        }

        /*Aguarda a invisibilidade de um determinado elemento na página*/
        public void AguardarElementoDesaparecer(By seletor)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(50))
                    .Until(ExpectedConditions.InvisibilityOfElementLocated(seletor));
            }
            catch (Exception e)
            {
                new Exception("O elemento ainda está sendo apresentado na tela. Motivo: " + e.Message);
            }
        }
        public virtual void AguardarElementoDesaparecer(By seletor, TimeSpan tempo)
        {
            try
            {
                new WebDriverWait(Driver, tempo)
                    .Until(ExpectedConditions.InvisibilityOfElementLocated(seletor));
            }
            catch (Exception e)
            {
                new Exception("O elemento ainda está sendo apresentado na tela. Motivo: " + e.Message);
            }
        }

        /*Aguarda o elemento ser Clicável*/
        public void AguardarClicarElemento(By seletor)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.ElementToBeClickable(seletor));
            }
            catch (Exception e)
            {
                new Exception("Ainda não é possível clicar no elemento. Motivo: " + e.Message);
            }
        }

        public virtual void AguardarClicarElemento(By seletor, TimeSpan tempo)
        {
            try
            {
                new WebDriverWait(Driver, tempo)
                    .Until(ExpectedConditions.ElementToBeClickable(seletor));
            }
            catch (Exception e)
            {
                new Exception("Ainda não é possível clicar no elemento. Motivo: " + e.Message);
            }
        }

        /*Aguarda o elemento ser Clicável*/
        public void AguardarSelecionarElemento(By seletor)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.ElementToBeSelected(seletor));
            }
            catch (Exception e)
            {
                new Exception("Ainda não é possível selecionar o elemento. Motivo: " + e.Message);
            }
        }
        public virtual void AguardarSelecionarElemento(By seletor, TimeSpan tempo)
        {
            try
            {
                new WebDriverWait(Driver, tempo)
                    .Until(ExpectedConditions.ElementToBeSelected(seletor));
            }
            catch (Exception e)
            {
                new Exception("Ainda não é possível selecionar o elemento. Motivo: " + e.Message);
            }
        }

        /*Aguarda elemento ser habilitado na tela*/
        public void AguardarHabilitarElemento(IWebElement elemento)
        {
            try
            {
                int segundos = 0;
                while (segundos < 60)
                {
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    
                    if (elemento.Enabled)
                        break;
                    else
                        segundos++;
                }
            }
            catch (Exception e)
            {
                new Exception("O elemento não foi habilitado na tela. Motivo: " + e.Message);
            }
        }
        public virtual void AguardarHabilitarElemento(IWebElement elemento, TimeSpan tempo)
        {
            try
            {
                int segundos = 0;
                while (segundos < 60)
                {
                    Driver.Manage().Timeouts().ImplicitWait = tempo;

                    if (elemento.Enabled)
                        break;
                    else
                        segundos++;
                }
            }
            catch (Exception e)
            {
                new Exception("O elemento não foi habilitado na tela. Motivo: " + e.Message);
            }
        }

        /*Aguarda elemento ser desabilitado na tela*/
        public void AguardarDesabilitarElemento(IWebElement elemento)
        {
            try
            {
                int segundos = 0;
                while (segundos < 60)
                {
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    if (elemento.Enabled)
                        segundos++;
                    else
                        break;
                }
            }
            catch (Exception e)
            {
                new Exception("O elemento não foi desabilitado na tela. Motivo: " + e.Message);
            }
        }
        public virtual void AguardarDesabilitarElemento(IWebElement elemento, TimeSpan tempo)
        {
            try
            {
                int segundos = 0;
                while (segundos < 60)
                {
                    Driver.Manage().Timeouts().ImplicitWait = tempo;

                    if (elemento.Enabled)
                        segundos++;
                    else
                        break;                    
                }
            }
            catch (Exception e)
            {
                new Exception("O elemento não foi desabilitado na tela. Motivo: " + e.Message);
            }
        }
        #endregion

        #region Ações

        /**Encontra um elemento do tipo campo texto por um seletor[Id, Name, Link, Css ou Xpath],
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual IWebElement EncontrarCampo(By seletor)
        {
            return Driver.FindElement(seletor);
        }

        /**Encontra um campo do tipo lista (ComboBox, DualList) 
        * por um seletor[Id, Name, Link, Css ou Xpath],
        * aguardando o carregamento dele antes de realizar a ação*/
        public virtual SelectElement EncontrarCampoLista(By seletor)
        {
            return new SelectElement(EncontrarCampo(seletor));
        }

        /**Encontra uma lista de elementos do tipo campo texto 
         * por um seletor[Id, Name, Link, Css ou Xpath],
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual List<IWebElement> EncontrarVariosCampos(By seletor)
        {
            return Driver.FindElements(seletor).ToList();
        }

        /**Digita valores em um elemento do tipo campo, 
         * o encontrando por um seletor[Id, Name, Link, Css ou Xpath] e 
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual void PreencherCampo(By seletor, String texto)
        {
            AguardarElemento(seletor);
            RolarAteElemento(seletor);
            LimparCampo(seletor);

            EncontrarCampo(seletor).SendKeys(texto);
        }
        public virtual void PreencherCampo(IWebElement elemento, String texto)
        {
            AguardarSegundos();
            RolarAteElemento(elemento);
            LimparCampo(elemento);

            if (elemento.Displayed)
                elemento.SendKeys(texto);
            else
                PreencherCampo(elemento, texto);
        }

        /**Seleciona um item no campo do tipo lista (ComboBox, DualList), por seu texto, 
         * após o encontrar por um seletor[Id, Name, Link, Css ou Xpath],
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual void SelecionarItemCampoListaPorTexto(By seletor, String texto)
        {
            AguardarElemento(seletor);
            RolarAteElemento(seletor);

            new SelectElement(Driver.FindElement(seletor)).SelectByText(texto);

            AguardarPaginaCarregar();
        }
        public virtual void SelecionarItemCampoListaPorTexto(IWebElement elemento, String texto)
        {
            AguardarSegundos();
            RolarAteElemento(elemento);

            new SelectElement(elemento).SelectByText(texto);

            AguardarPaginaCarregar();
        }

        /**Seleciona um item no campo do tipo lista (ComboBox, DualList), por seu valor, 
         * após o encontrar por um seletor[Id, Name, Link, Css ou Xpath],
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual void SelecionarItemCampoListaPorValor(By seletor, String Valor)
        {
            AguardarElemento(seletor);
            RolarAteElemento(seletor);

            new SelectElement(EncontrarCampo(seletor)).SelectByValue(Valor);

            AguardarPaginaCarregar();
        }
        public virtual void SelecionarItemCampoListaPorValor(IWebElement elemento, String Valor)
        {
            AguardarSegundos();
            RolarAteElemento(elemento);

            new SelectElement(elemento).SelectByValue(Valor);

            AguardarPaginaCarregar();
        }

        /**Seleciona um item no campo do tipo lista (ComboBox, DualList), por seu valor, 
         * após o encontrar por um seletor[Id, Name, Link, Css ou Xpath],
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual void SelecionarItemCampoListaPorIndex(By seletor, int Index)
        {
            AguardarElemento(seletor);
            RolarAteElemento(seletor);

            new SelectElement(EncontrarCampo(seletor)).SelectByIndex(Index);

            AguardarPaginaCarregar();
        }
        public virtual void SelecionarItemCampoListaPorIndex(IWebElement elemento,int Index)
        {
            AguardarSegundos();
            RolarAteElemento(elemento);

            new SelectElement(elemento).SelectByIndex(Index);

            AguardarPaginaCarregar();
        }

        /**Retira a seleção de todos os itens no campo do tipo lista (ComboBox, DualList), 
         * após o encontrar por um seletor[Id, Name, Link, Css ou Xpath],
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual void DesselecionarItemCampoLista(By seletor)
        {
            AguardarElemento(seletor);
            RolarAteElemento(seletor);

            new SelectElement(EncontrarCampo(seletor)).DeselectAll();

            AguardarPaginaCarregar();
        }
        public virtual void DesselecionarItemCampoLista(IWebElement elemento)
        {
            AguardarSegundos();
            RolarAteElemento(elemento);

            new SelectElement(elemento).DeselectAll();

            AguardarPaginaCarregar();
        }

        /**Captura um valore digitado em um elemento do tipo campo texto ou label, 
         * o encontrando por um seletor[Id, Name, Link, Css ou Xpath] e 
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual String PegarValorCampo(By seletor)
        {
            AguardarElemento(seletor);
            RolarAteElemento(seletor);

            return EncontrarCampo(seletor).Text;
        }

        public virtual String PegarValorCampo(IWebElement elemento)
        {
            AguardarSegundos();
            RolarAteElemento(elemento);

            return elemento.Text;
        }


        /**Captura um valor selecionado em um elemento do tipo campo texto ou combo, 
         * o encontrando por um seletor[Id, Name, Link, Css ou Xpath] e 
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual String PegarValorCampoLista(By seletor)
        {
            AguardarSegundos();
            RolarAteElemento(seletor);

            return new SelectElement(this.EncontrarCampo(seletor)).SelectedOption.Text;
        }
        public virtual String PegarValorCampoLista(IWebElement elemento)
        {
            AguardarSegundos();
            RolarAteElemento(elemento);

            return new SelectElement(elemento).SelectedOption.Text;
        }

        public virtual String PegarTexto(By seletor)
        {
            AguardarElemento(seletor);
            RolarAteElemento(seletor);            
                 
            return EncontrarCampo(seletor).Text;
        }

        /**Captura um valore digitado em um elemento do tipo campo texto ou label, 
        * o encontrando por um seletor[Id, Name, Link, Css ou Xpath] e 
        * aguardando o carregamento dele antes de realizar a ação*/
        public virtual String PegarValorSoltoCampo(By seletor)
        {
            FecharPopup();
            AguardarElemento(seletor);
            RolarAteElemento(seletor);

            return EncontrarCampo(seletor).GetAttribute("innerText");
        }
        public virtual String PegarValorSoltoCampo(IWebElement elemento)
        {
            AguardarSegundos();
            RolarAteElemento(elemento);

            return elemento.GetAttribute("innerText");
        }

        /**Captura um valor apresentado em uma popup, 
        * o encontrando por um seletor[Id, Name, Link, Css ou Xpath] e 
        * aguardando o carregamento dele antes de realizar a ação*/
        public virtual String PegarValorTextoPopup(By seletor)
        {
            Driver.SwitchTo().ParentFrame();

            AguardarElemento(seletor);

            return EncontrarCampo(seletor).Text;
        }
        public virtual String PegarValorTextoPopup(IWebElement elemento)
        {
            Driver.SwitchTo().ParentFrame();

            AguardarSegundos();

            return elemento.Text;
        }

        public virtual String PegarValorElemento(IWebElement elemento)
        {
            AguardarSegundos();
            return elemento.Text;
        }

        /**Limpa valores Digitados em um elemento do tipo campo, 
         * o encontrando por um seletor[Id, Name, Link, Css ou Xpath] e 
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual void LimparCampo(By seletor)
        {
            EncontrarCampo(seletor).Clear();
        }
        public virtual void LimparCampo(IWebElement elemento)
        {
            elemento.Clear();
        }

        /**Realiza ação de clique em um elemento do tipo Botão, Link ou Checkbox, 
         * o encontrando por um seletor[Id, Name, Link, Css ou Xpath] e 
         * aguardando o carregamento dele antes de realizar a ação*/
        public virtual void Clicar(By seletor)
        {            
            RolarAteElemento(seletor);
            AguardarVerElemento(seletor, TimeSpan.FromSeconds(50));
            AguardarClicarElemento(seletor, TimeSpan.FromMinutes(1));
            EncontrarCampo(seletor).Click();            
            AguardarPaginaCarregar();
        }

        public virtual void Clicar(IWebElement elemento)
        {   
            AguardarSegundos();
            RolarAteElemento(elemento);
            AguardarSegundos();
            elemento.Click();         
            AguardarPaginaCarregar();
        }

        public virtual void SubmeterFormulario(By seletor)
        {
            RolarAteElemento(seletor);
            AguardarVerElemento(seletor, TimeSpan.FromSeconds(50));
            AguardarClicarElemento(seletor, TimeSpan.FromMinutes(1));
            EncontrarCampo(seletor).Submit();
            AguardarPaginaCarregar();
            AguardarElementoDesaparecer(seletor, TimeSpan.FromMinutes(1));
        }

        #endregion

        #region Alerts

        /**Aguarda a condição de apresentação de um alert,
         por até 30 segundos e em caso negativo, falha*/
        public virtual void AguadarAlert()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.AlertIsPresent());
        }

        /**Aguarda a condição de apresentação de um alert,
         por tempo parametrizado e em caso negativo falha*/
        public virtual void AguadarAlert(TimeSpan tempo)
        {
            new WebDriverWait(Driver, tempo)
                .Until(ExpectedConditions.AlertIsPresent());
        }
        
        public virtual void FecharPopup()
        {
            if (new AssertUtils(Driver).ValidarAlert())
                Driver.SwitchTo().Alert().Dismiss();
        }

        #endregion

        #region Scroll

        public virtual void RolarParaFim(IWebDriver Driver)
        {
            IJavaScriptExecutor JS = (IJavaScriptExecutor)Driver;
            JS.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
        
        public virtual void RolarParaBaixo(IWebDriver Driver)
        {
            IJavaScriptExecutor JS = (IJavaScriptExecutor)Driver;
            JS.ExecuteScript("scroll(0, 2500);");
        }

        public virtual void RolarParaCima(IWebDriver Driver)
        {
            IJavaScriptExecutor JS = (IJavaScriptExecutor)Driver;
            JS.ExecuteScript("scroll(2500, 0);");
        }
        

        public virtual void RolarAteElemento(By seletor)
        {
            IWebElement elemento = Driver.FindElement(seletor);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", elemento);
        }

        public virtual void RolarAteElemento(IWebElement _Elemento)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", _Elemento);
        }

        #endregion
    }
}
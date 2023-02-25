using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjetoDeCadastroNivelBasico.Hooks;

namespace ProjetoDeCadastroNivelBasico.PageObjects
{
    class Biblioteca
    {
        public IWebDriver driver;

        private By BotaoCadastrar = By.Id("elementosForm:cadastrar");
        private By Nome => By.Id("elementosForm:nome");
        private By Sobrenome => By.Id("elementosForm:sobrenome");
        private By Alert => By.Id("alert");
        private By Confirm => By.Id("confirm");
        private By Prompt => By.Id("prompt");
        private By Frame => By.Id("frameButton");
        private By PopUp => By.Id("buttonPopUpHard");
        private By TextPopUp => By.Id("textarea");
        private By Sugestoes => By.Id("elementosForm:sugestoes");
        IWebElement Escolaridade => driver.FindElement(By.Id("elementosForm:escolaridade"));
        IWebElement Esportes => driver.FindElement(By.Id("elementosForm:esportes"));
        IWebElement ResultadoCadastro => driver.FindElement(By.Id("resultado"));

        public Biblioteca()
        {
            driver = Hooks.Hooks.driver;
        }
        public void BtnCadastrar()
        {
            driver.FindElement(BotaoCadastrar).Click();
        }

        public void CampoNome(string Texto)
        {

            driver.FindElement(Nome).SendKeys(Texto);
        }

        public void CampoSobrenome(string Texto)
        {

            driver.FindElement(Sobrenome).SendKeys(Texto);
        }

        public void SexoMasculino()
        {
            driver.FindElement(By.Id("elementosForm:sexo:0")).Click();
        }

        public void SexoFeminino()
        {
            driver.FindElement(By.Id("elementosForm:sexo:1")).Click();
        }

        public void FlagComidaCarne()
        {
            driver.FindElement(By.Id("elementosForm:comidaFavorita:0")).Click();
        }

        public void FlagComidaVegetariano()
        {
            driver.FindElement(By.Id("elementosForm:comidaFavorita:3")).Click();
        }

        public void EsporteNatacao()
        {
            SelectElement RetornoEsporte = new SelectElement(Esportes);
            RetornoEsporte.SelectByText("Natacao");
        }


        public string ObterResultadoCadastro()
        {
            return driver.FindElement(By.CssSelector("#resultado > span")).Text;
        }

        public string ObterResultadoNome()
        {

            return driver.FindElement(By.CssSelector("#descNome > span")).Text;

        }

        public string ObterResultadoSobreNome()
        {

            return driver.FindElement(By.CssSelector("#descSobrenome > span")).Text;

        }
        public string ObterResultadoSexo()
        {

            return driver.FindElement(By.CssSelector("#descSexo > span")).Text;

        }
        public string ObterResultadoComidas()
        {

            return driver.FindElement(By.CssSelector("#descComida > span")).Text;

        }
        public string ObterResultadoEscolaridade()
        {

            return driver.FindElement(By.CssSelector("#descEscolaridade > span")).Text;

        }

        public string ObterResultadoEsportes()
        {

            return driver.FindElement(By.CssSelector("#descEsportes > span")).Text;

        }







        public void Mestrado()
        {
            SelectElement RetornoEscolaridade = new SelectElement(Escolaridade);
            RetornoEscolaridade.SelectByValue("mestrado");

        }


        public string ObterAlerta()
        {

            return driver.SwitchTo().Alert().Text;
        }

        public void Alerta(string textoaviso)
        {
            Assert.AreEqual(textoaviso, ObterAlerta());

        }

        public void PrintScreen()
        {
            var data = DateTime.Now.ToString("yyyyMMddTHH-mm-ss");
            Directory.CreateDirectory("E://"+data+"");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("E://"+data+"\\PrintTeste.png",
            ScreenshotImageFormat.Png);

        }

    
        public void CampoNomeAlternativo(string name)
        {
            IWebElement userNameField = null;
            var userNameField2 = driver.FindElement(By.XPath("//td[2]/input"));
            try
            {
                userNameField = driver.FindElement(By.Id("elementosForm:nome"));

            }
            catch (NoSuchElementException e)
            {
            }
            if (userNameField != null)
            {
                userNameField.SendKeys(name);
            }
            else
            {
                userNameField2.SendKeys(name);
            }

        }







    }
}
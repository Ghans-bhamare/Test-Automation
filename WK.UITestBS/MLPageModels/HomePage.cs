using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace WK.UITest.MLPageModels
{
    public class HomePage
    {
        private IWebDriver driver;

        private By HomeMenu = By.XPath("//a[@href='/oss/ml']");
        private By tutorials = By.XPath("//a[normalize-space()='Tutorials']");
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void clickOnTutorials()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, tutorials);
                element.Click();
                Thread.Sleep(3000);
                Logger.log.Info("Clicked on Tutorials link on Home Page");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnMinimizeChat()
        {
            string exceptionMessage = string.Empty;
            try
            {
               // String cssSelectorForHost1 = "app-chat-bot";
                Thread.Sleep(1000);
                ISearchContext shadow = driver.FindElement(By.CssSelector("app-chat-bot")).GetShadowRoot();
                Thread.Sleep(1000);
                shadow.FindElement(By.CssSelector(".minimizeChat")).Click();
                //IWebElement element = CommonActions.WaitUntilElementVisible(driver, minimizeChat);
                //element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
    }
}

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace WK.UITest.CanadaPageModels
{
    public class PrivacyPolicyPage
    {
        private IWebDriver driver;

        private By yourPrivacyPopUp = By.XPath("//div[@id='onetrust-policy']");

        private By rejectCookies = By.XPath("//button[@id='onetrust-reject-all-handler']");
        private By acceptCookies = By.XPath("//button[@id='onetrust-accept-btn-handler']");

       
        private By canadaQuebec = By.XPath("//div[@tooltipposition='top']//span[contains(text(),'ADDITIONAL INFORMATION FOR QUEBEC AND CANADIAN RES')]");


        public PrivacyPolicyPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool isYourPrivacyPopUp()
        {
            string exceptionMessage = string.Empty;
            try
            {
                Thread.Sleep(3000);
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, yourPrivacyPopUp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void clickOnAcceptCookies()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, acceptCookies);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnPrivacyCookies_AdditionalInfo_Quebec()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, canadaQuebec);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }


        public void clickOnRejectCookies()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, rejectCookies);
                element.Click();
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


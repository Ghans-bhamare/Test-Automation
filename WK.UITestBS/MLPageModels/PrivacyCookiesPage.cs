using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace WK.UITest.MLPageModels
{
    public class PrivacyCookiesPage
    {
        private IWebDriver driver;

        private By yourPrivacyPopUp = By.XPath("//div[@id='onetrust-banner-sdk']");
        private By rejectCookies = By.XPath("//button[@id='onetrust-reject-all-handler']");
        private By acceptCookies = By.XPath("//button[@id='onetrust-accept-btn-handler']");


       

        public PrivacyCookiesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool isYourPrivacyPopUp()
        {
            string exceptionMessage = string.Empty;
            try
            {
                CommonActions.WaitForPageLoad(driver);
                Thread.Sleep(3000);
                bool flag = CommonActions.IsElementPresent(driver, yourPrivacyPopUp);
                if(flag)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
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


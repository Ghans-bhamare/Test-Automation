using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace WK.UITest.CanadaPageModels
{
    public class HomePage
    {
        private IWebDriver driver;

        private By supportCases = By.XPath("//span[normalize-space()='Support Cases'] | //span[normalize-space()='Cas de soutien']");
        private By viewCases = By.XPath("//span[normalize-space()='My support cases']");
        private By openCase = By.XPath("//span[normalize-space()='Open a support case'] | //a[@class='p-ripple p-element p-menuitem-link ng-star-inserted']//span[normalize-space()='Ouvrir un cas de soutien']");
        private By knowledgeBase = By.XPath("//span[normalize-space()='Knowledge Base']");
        private By knowledgeBaseMenu = By.XPath("//span[normalize-space()='Knowledge Databases']");
        private By accountSettings = By.XPath("//*[contains(text(),'Account settings')]");
        private By contactUsMenu = By.XPath("(//span[normalize-space()='Contact Us'])[1] | (//span[normalize-space()='Nous joindre'])[1]");
        private By remoteSupportSession = By.XPath("//span[normalize-space()='Remote support session'] | //span[normalize-space()='Session de soutien à distance']");
        private By chat = By.XPath("//span[normalize-space()='Chat with representative']");
        private By videoTutorials = By.XPath("//span[normalize-space()='Video Tutorials']");

        private By loginButton = By.XPath("//button[normalize-space()='Log in']");

        private By language = By.XPath("(//*[name()='svg'][@class='p-dropdown-trigger-icon p-icon'])[1]");
        private By languageEnglish = By.XPath("//span[normalize-space()='Anglais']");
        private By languageFrench = By.XPath("(//span[normalize-space()='French'])[1]");

        private By userAvatar = By.XPath("//span[@class='pi pi-user p-avatar-icon ng-star-inserted']");
        private By logoutButton = By.XPath("//span[normalize-space()='Log out'] | //span[normalize-space()='Se déconnecter']");
        private By confirmLogoutButton = By.XPath("//button[normalize-space()='Yes, log out'] | //button[normalize-space()='Oui, se déconnecter']");

        private By homeButton = By.XPath("//span[normalize-space()='Accueil'] | //span[normalize-space()='Home']");

        private By minimizeChat = By.XPath("//div[@class='minimizeChat']");
        private By privacyPolicy = By.XPath("//a[normalize-space()='Privacy & Cookies']");
         

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickOnVideoTutorials()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, videoTutorials);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnContactUsMenu()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, contactUsMenu);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnRemoteSupportSession()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, remoteSupportSession);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnChatWithRepresentative()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, chat);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

      
        public string getHomeButton_Text()
        {
            string exceptionMessage = string.Empty;
            try
            {
                Thread.Sleep(3000);
                return CommonActions.WaitUntilElementVisible(driver, homeButton).Text;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }


        public void clickOnConfirmLogOut()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, confirmLogoutButton);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Clicked on I want to");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
        public void clickOnLogin()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, loginButton);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Clicked on I want to");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnUser()
        {
            string exceptionMessage = string.Empty;
            try
            {
                Thread.Sleep(4000);
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, userAvatar);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Clicked on I want to");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
        public void clickOnLogOut()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, logoutButton);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Clicked on I want to");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
        public void clickOnSupportCases()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, supportCases);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Clicked on I want to");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }


        public void clickOnViewMyCases()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, viewCases);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Clicked on View my cases");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnOpenCase()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, openCase);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Clicked on Open a case");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
        public void clickOnAccountSettings()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, accountSettings);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
        public void clickOnKnowledgeBase()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, knowledgeBase);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnKnowledgeBaseMenu()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, knowledgeBaseMenu);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnLanguageDropdown()
        {
            string exceptionMessage = string.Empty;
            try
            {
                Thread.Sleep(7000);
                IWebElement element = CommonActions.SafeClick(driver, language);
                Thread.Sleep(7000);
                //Logger.log.Info(("Clicked on Language Dropdown");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void selectLanguageEnglish()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, languageEnglish);
                Thread.Sleep(3000);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Selected language as English");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void selectLanguageFrench()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, languageFrench);
                element.Click();
                Thread.Sleep(3000);
                //Logger.log.Info(("Selected language as French");
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
                String cssSelectorForHost1 = "app-chat-bot";
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
        public void clickOnPrivacyPolicy()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, privacyPolicy);
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

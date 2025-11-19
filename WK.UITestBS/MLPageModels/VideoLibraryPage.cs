using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using System;
using AventStack.ExtentReports.MarkupUtils;

namespace WK.UITest.MLPageModels
{
    public class VideoLibraryPage
    {

        private IWebDriver driver;

        public VideoLibraryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By mostViewed = By.XPath("//div[contains(text(),'Most Viewed')]");
        private By hotTopics = By.XPath("//div[contains(text(),'Hot Topics')]");
        private By clearAll = By.XPath("//div[@class='clear-filter-text']");

        private By resultsPerPage = By.XPath("//div[@aria-label='dropdown trigger']");

        private By results_15 = By.XPath("//li[@aria-label='15']");
        private By results_25 = By.XPath("//li[@aria-label='25']");
        private By results_50 = By.XPath("//li[@aria-label='50']");

        private By nextPage = By.XPath("//button[@class='p-ripple p-element p-paginator-next p-paginator-element p-link']");
        private By previousPage = By.XPath("//button[@class='p-ripple p-element p-paginator-prev p-paginator-element p-link']");

        private By video = By.XPath("(//img[@class='thumbnail'])[1]");


        public void verifyVideo()
        {
            string exceptionMessage = string.Empty;
            try
            {
                int cnt = driver.FindElements(By.XPath("(//div[@class='video-card'])")).Count;
                Logger.log.Pass(cnt + " Video/s appeared on page");

                for (int i = 0; i < cnt; i++)
                {
                    Logger.log.Pass("Details of a Video " + (i + 1) + " is as follows");

                    string topic = driver.FindElement(By.XPath("(//div[@class='video-card'])[" + (i + 1) + "]//descendant::div[2]/div[1]")).Text;
                    string title = driver.FindElement(By.XPath("(//div[@class='video-card'])[" + (i + 1) + "]//descendant::div[2]/div[2]")).Text;
                    string duration = driver.FindElement(By.XPath("(//div[@class='video-card'])[" + (i + 1) + "]//descendant::div[2]//div[3]//p[1]")).Text;
                    string views = driver.FindElement(By.XPath("(//div[@class='video-card'])[" + (i + 1) + "]//descendant::div[2]//div[3]//p[2]")).Text;
                    string articleAvailable = string.Empty;
                    if (CommonActions.IsElementPresent(driver, By.XPath("(//div[@class='video-card'])[" + (i + 1) + "]//descendant::div[2]//div[4]")))
                    {
                        articleAvailable = "Yes";
                    }
                    else articleAvailable = "No";

                    String[,] data = {
                                        { "Topic : " , topic },
                                        { "Title : ", title },
                                        { "Duration : ", duration },
                                        { "Views : ", views },
                                        { "Article Available? : ", articleAvailable }
                    };
                    Logger.log.Info(MarkupHelper.CreateTable(data));
                }
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }


        public void clickOnVideo()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, video);
                element.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnMostViewed()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, mostViewed);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnHotTopics()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, hotTopics);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnClearAll()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, clearAll);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnResultsPerPage()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, resultsPerPage);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void selectResultsPerPage_15()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, results_15);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void selectResultsPerPage_25()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, results_25);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void selectResultsPerPage_50()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, results_50);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnNextPage()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, nextPage);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void clickOnPreviousPage()
        {
            string exceptionMessage = string.Empty;
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, previousPage);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void selectCatrgory(string givenCategory)
        {
            string exceptionMessage = string.Empty;
            By category = By.XPath("//label[normalize-space()='" + givenCategory + "']");
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, category);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void selectTopic(string givenTopic)
        {
            string exceptionMessage = string.Empty;
            By topic = By.XPath("//label[normalize-space()='" + givenTopic + "']");
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, topic);
                element.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

    }
}
using AventStack.ExtentReports;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Data.SqlClient;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace WK.UITest
{
    public class CommonActions
    {
        public static IWebDriver LaunchApplication(IWebDriver driver, string URL, string DriverPath, Browsers Browser = Browsers.Chrome)
        {
            try
            {
                if (IsLocalDebug())
                    Browser = Browsers.Chrome;
                switch (Browser)
                {
                    case Browsers.IE:
                        var options = new InternetExplorerOptions();
                        options.RequireWindowFocus = true;
                        driver = new InternetExplorerDriver(DriverPath, options);
                        driver.Manage().Window.Maximize();
                        break;
                    case Browsers.Chrome:
                        var options1 = new ChromeOptions();
                        options1.AddArgument("--test-type");
                        options1.PageLoadStrategy = PageLoadStrategy.None;
                        driver = new ChromeDriver(DriverPath, options1);
                        driver.Manage().Window.Maximize();
                        break;
                    case Browsers.Firefox:
                        driver = new FirefoxDriver(DriverPath);
                        driver.Manage().Window.Maximize();
                        break;
                    case Browsers.Headless:
                        ChromeOptions option = new ChromeOptions();
                        option.AddArgument("--disable-gpu");
                        option.AddArgument("--no-sandbox");
                        option.AddArgument("--disable-dev-shm-usage");
                        option.AddArgument("--disable-browser-side-navigation");
                        option.AddArgument("--disable-infobars");
                        option.AddArgument("--headless=new");
                        option.AddArgument("--test-type");
                        option.AddArgument("--window-size=1920,1080");
                        TimeSpan commandTimeout = TimeSpan.FromMinutes(1);
                        driver = new ChromeDriver(DriverPath, option);
                        break;
                    default:
                        break;
                }
                //driver = BuildBrowserStackDriver();
                driver = LaunchUrl(driver, URL);
                Thread.Sleep(2500);

                if (URL.Contains("cch.com/oss/ml"))
                {
                    WK.UITest.MLPageModels.PrivacyCookiesPage objPrivacyCookiesPage = new WK.UITest.MLPageModels.PrivacyCookiesPage(driver);
                    if (objPrivacyCookiesPage.isYourPrivacyPopUp())
                    {
                        objPrivacyCookiesPage.clickOnAcceptCookies();
                        Thread.Sleep(4000);
                    }
                }
                return driver;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //public static IWebDriver BuildBrowserStackDriver()
        //{
        //    DriverOptions capability = new OpenQA.Selenium.Chrome.ChromeOptions();
        //    capability.BrowserVersion = "latest";

        //    return new RemoteWebDriver(
        //      new Uri("https://hub-cloud.browserstack.com/wd/hub"),
        //      capability
        //    );

        //}

        public static IWebDriver LaunchUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            return driver;
        }


        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementClickable(IWebDriver driver, By elementLocator, int timeout = 150)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(150));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Element with locator: '" + elementLocator + "' was not found.");
            }
        }

        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementVisible(IWebDriver driver, By elementLocator, int timeout = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Element with locator: '" + elementLocator + "' was not found.");
            }
        }

        public static IWebElement SafeClick(IWebDriver driver, By locator, int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            // Wait for common overlays to disappear
            wait.Until(d =>
            {
                var spinners = d.FindElements(By.XPath("//ngx-spinner[@type='ball-spin-clockwise']"));
                return spinners.All(s => !s.Displayed);
            });


            // Wait for the element to be clickable
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            // Scroll into view
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // Click the element
            element.Click();

            // Return the clicked element
            return element;

        }

        public static bool IsElementPresent(IWebDriver driver, By elementName)
        {
            Thread.Sleep(1000);
            try { driver.FindElement(elementName); }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
            return true;
        }

        public static string GetBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int start = strSource.IndexOf(strStart) + strStart.Length;
                int end = strSource.IndexOf(strEnd, start);
                return strSource.Substring(start, end - start);
            }
            return "";
        }

        public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds = 60)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(d =>
                {
                    var jsExecutor = (IJavaScriptExecutor)d;
                    return jsExecutor.ExecuteScript("return document.readyState").ToString().Equals("complete");
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception("Timeout while waiting for page load: " + ex.Message);
            }
        }

        public static void ScrollUntilElementFound(IWebDriver driver,IWebElement element)
        {
            try
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception("Timeout while waiting for page load: " + ex.Message);
            }
        }
        public static void ClickElement(IWebDriver driver, By locator, int sleepMs = 3000, [CallerMemberName] string callerName = "")
        {
            try
            {
                IWebElement element = CommonActions.WaitUntilElementVisible(driver, locator);
                element.Click();
                Thread.Sleep(sleepMs);
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + callerName + ". Exception is: " + exceptionMessage);
            }
        }

        private static bool IsLocalDebug() { return System.Diagnostics.Debugger.IsAttached; }
    }


    public enum Browsers
    {
        /// <summary>
        /// The ie
        /// </summary>
        IE,
        /// <summary>
        /// The chrome
        /// </summary>
        Chrome,
        /// <summary>
        /// The firefox
        /// </summary>
        Firefox,
        Headless
    }
}

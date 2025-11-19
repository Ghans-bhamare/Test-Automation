using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace WK.UITest.CanadaPageModels
{
    public class VideoDisplayPage
    {

        private IWebDriver driver;

        public VideoDisplayPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
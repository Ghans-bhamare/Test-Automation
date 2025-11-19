using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WK.UITest.MLPageModels;
using WK.UITest.CanadaPageModels;
using System.Threading;

namespace WK.UITest.OneSupportPortalUI
{
    [TestClass]
    public class VideoLibraryTest : UITestBase
    {
        /*--------------------- START :  ML OSS Test Cases ---------------------*/

        [TestMethod, TestCategory("OSS_P0")]
        public void ML_AccessVideoLibrary_HomePage_ExternalUser()
        {
            try
            {
                Logger.log = logger.CreateTest(TestContext.TestName + " - " + "Headless");

                // Launch Support Portal Application
                driver = CommonActions.LaunchApplication(driver, urlML, driverPath, (Browsers)Enum.Parse(typeof(Browsers), "Headless"));
                Thread.Sleep(5000);

                WK.UITest.MLPageModels.HomePage objHomePage = new WK.UITest.MLPageModels.HomePage(driver);
                WK.UITest.MLPageModels.VideoLibraryPage objVideoLibraryPage = new WK.UITest.MLPageModels.VideoLibraryPage(driver);

                objHomePage.clickOnTutorials();
                Thread.Sleep(2000);

                objHomePage.clickOnMinimizeChat();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnPreviousPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnPreviousPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnVideo();
                Thread.Sleep(3000);
                Logger.log.Pass("Clicked on First Video Thumbnail");
                Logger.log.Pass("URL " + driver.Url);

                Logger.log.Pass("Checked Video Library Page Successfully");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Logger.log.Fail(ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod, TestCategory("OSS_P0")]
        public void ML_AccessVideoLibrary_DirectURL_ExternalUser()
        {
            try
            {
                Logger.log = logger.CreateTest(TestContext.TestName + " - " + "Headless");

                // Launch Support Portal Application
                driver = CommonActions.LaunchApplication(driver, urlML, driverPath, (Browsers)Enum.Parse(typeof(Browsers), "Headless"));
                Thread.Sleep(5000);

                WK.UITest.MLPageModels.HomePage objHomePage = new WK.UITest.MLPageModels.HomePage(driver);
                WK.UITest.MLPageModels.VideoLibraryPage objVideoLibraryPage = new WK.UITest.MLPageModels.VideoLibraryPage(driver);

                driver.Navigate().GoToUrl("https://support-demo.cch.com/oss/ml/videolibrary");
                Thread.Sleep(2000);

                objHomePage.clickOnMinimizeChat();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnPreviousPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnPreviousPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnVideo();
                Thread.Sleep(3000);
                Logger.log.Pass("Clicked on First Video Thumbnail");
                Logger.log.Pass("URL " + driver.Url);

                Logger.log.Pass("Checked Video Library Page Successfully");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Logger.log.Fail(ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod, TestCategory("OSS_P0")]
        public void ML_HotTopicsAndMostViewed_ExternalUser()
        {
            try
            {
                Logger.log = logger.CreateTest(TestContext.TestName + " - " + "Headless");

                // Launch Support Portal Application
                driver = CommonActions.LaunchApplication(driver, urlML, driverPath, (Browsers)Enum.Parse(typeof(Browsers), "Headless"));
                Thread.Sleep(5000);

                WK.UITest.MLPageModels.HomePage objHomePage = new WK.UITest.MLPageModels.HomePage(driver);
                WK.UITest.MLPageModels.VideoLibraryPage objVideoLibraryPage = new WK.UITest.MLPageModels.VideoLibraryPage(driver);


                objHomePage.clickOnTutorials();
                Thread.Sleep(2000);

                objHomePage.clickOnMinimizeChat();
                Thread.Sleep(2000);

                //Most Viewed

                objVideoLibraryPage.clickOnMostViewed();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                Logger.log.Pass("Checked Most Viewed");
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnPreviousPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnPreviousPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnClearAll();
                Thread.Sleep(2000);

                //Hot Topics

                objVideoLibraryPage.clickOnHotTopics();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_15();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                Logger.log.Pass("Checked Hot Topics");
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnNextPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnPreviousPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnMostViewed();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnVideo();
                Thread.Sleep(3000);
                Logger.log.Pass("Clicked on First Video Thumbnail");
                Logger.log.Pass("URL " + driver.Url);

                Logger.log.Pass("Checked Hot Topics and Most Viewed Tabs Successfully");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Logger.log.Fail(ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod, TestCategory("OSS_P0")]
        public void ML_CategoryAndTopic_ExternalUser()
        {
            try
            {
                Logger.log = logger.CreateTest(TestContext.TestName + " - " + "Headless");

                // Launch Support Portal Application
                driver = CommonActions.LaunchApplication(driver, urlML, driverPath, (Browsers)Enum.Parse(typeof(Browsers), "Headless"));
                Thread.Sleep(5000);

                WK.UITest.MLPageModels.HomePage objHomePage = new WK.UITest.MLPageModels.HomePage(driver);
                WK.UITest.MLPageModels.VideoLibraryPage objVideoLibraryPage = new WK.UITest.MLPageModels.VideoLibraryPage(driver);

                objHomePage.clickOnTutorials();
                Thread.Sleep(2000);

                objHomePage.clickOnMinimizeChat();
                Thread.Sleep(2000);

                //Category and Topic

                objVideoLibraryPage.selectCatrgory("Billing and Account Administration");
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectTopic("Supply Orders");
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnVideo();
                Thread.Sleep(3000);
                Logger.log.Pass("Clicked on First Video Thumbnail");
                Logger.log.Pass("URL " + driver.Url);

                Logger.log.Pass("Checked Video Library Page Successfully");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Logger.log.Fail(ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }

        /*--------------------- END : ML OSS Test Cases ---------------------*/


        /*--------------------- START :  Canada OSS Test Cases ---------------------*/

        [TestMethod, TestCategory("OSS_P0")]
        public void Canada_AccessVideoLibrary_DirectURL_ExternalUser()
        {
            try
            {
                Logger.log = logger.CreateTest(TestContext.TestName + " - " + "Headless");

                // Launch Support Portal Application
                driver = CommonActions.LaunchApplication(driver, urlCanada, driverPath, (Browsers)Enum.Parse(typeof(Browsers), "Headless"));
                Thread.Sleep(6000);

                WK.UITest.CanadaPageModels.HomePage objHomePage = new WK.UITest.CanadaPageModels.HomePage(driver);
                WK.UITest.CanadaPageModels.VideoLibraryPage objVideoLibraryPage = new WK.UITest.CanadaPageModels.VideoLibraryPage(driver);

                driver.Navigate().GoToUrl("https://support-demo.cch.com/oss/canada/videolibrary");
                Thread.Sleep(2000);

                objHomePage.clickOnMinimizeChat();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnVideo();
                Thread.Sleep(3000);
                Logger.log.Pass("Clicked on First Video Thumbnail");
                Logger.log.Pass("URL " + driver.Url);

                Logger.log.Pass("Checked Video Library Page Successfully");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Logger.log.Fail(ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod, TestCategory("OSS_P0")]
        public void Canada_HotTopicsAndMostViewed_ExternalUser()
        {
            try
            {
                Logger.log = logger.CreateTest(TestContext.TestName + " - " + "Headless");

                // Launch Support Portal Application
                driver = CommonActions.LaunchApplication(driver, urlCanada, driverPath, (Browsers)Enum.Parse(typeof(Browsers), "Headless"));
                Thread.Sleep(6000);

                WK.UITest.CanadaPageModels.HomePage objHomePage = new WK.UITest.CanadaPageModels.HomePage(driver);
                WK.UITest.CanadaPageModels.VideoLibraryPage objVideoLibraryPage = new WK.UITest.CanadaPageModels.VideoLibraryPage(driver);

                objHomePage.clickOnKnowledgeBaseMenu();
                Thread.Sleep(2000);

                objHomePage.clickOnVideoTutorials();
                Thread.Sleep(2000);

                objHomePage.clickOnMinimizeChat();
                Thread.Sleep(2000);

                //Most Viewed

                objVideoLibraryPage.clickOnMostViewed();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                Logger.log.Pass("Checked Most Viewed");
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                //Hot Topics

                objVideoLibraryPage.clickOnHotTopics();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_15();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                Logger.log.Pass("Checked HotTopics");
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnMostViewed();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnVideo();
                Thread.Sleep(3000);
                Logger.log.Pass("Clicked on First Video Thumbnail");
                Logger.log.Pass("URL " + driver.Url);

                Logger.log.Pass("Checked Hot Topics and Most Viewed Tabs Successfully");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Logger.log.Fail(ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod, TestCategory("OSS_P0")]
        public void Canada_CategoryAndTopic_ExternalUser()
        {
            try
            {
                Logger.log = logger.CreateTest(TestContext.TestName + " - " + "Headless");

                // Launch Support Portal Application
                driver = CommonActions.LaunchApplication(driver, urlCanada, driverPath, (Browsers)Enum.Parse(typeof(Browsers), "Headless"));
                Thread.Sleep(6000);

                WK.UITest.CanadaPageModels.HomePage objHomePage = new WK.UITest.CanadaPageModels.HomePage(driver);
                WK.UITest.CanadaPageModels.VideoLibraryPage objVideoLibraryPage = new WK.UITest.CanadaPageModels.VideoLibraryPage(driver);


                objHomePage.clickOnKnowledgeBaseMenu();
                Thread.Sleep(2000);

                objHomePage.clickOnVideoTutorials();
                Thread.Sleep(2000);

                objHomePage.clickOnMinimizeChat();
                Thread.Sleep(2000);

                //Category and Topic

                objVideoLibraryPage.selectCatrgory("Cantax");
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectTopic("Cantax T2");
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnVideo();
                Thread.Sleep(3000);
                Logger.log.Pass("Clicked on First Video Thumbnail");
                Logger.log.Pass("URL " + driver.Url);

                Logger.log.Pass("Checked Video Library Page Successfully");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Logger.log.Fail(ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod, TestCategory("OSS_P0")]
        public void Canada_ChangeLanguage_ExternalUser()
        {
            try
            {
                Logger.log = logger.CreateTest(TestContext.TestName + " - " + "Headless");

                // Launch Support Portal Application
                driver = CommonActions.LaunchApplication(driver, urlCanada, driverPath, (Browsers)Enum.Parse(typeof(Browsers), "Headless"));
                Thread.Sleep(6000);

                WK.UITest.CanadaPageModels.HomePage objHomePage = new WK.UITest.CanadaPageModels.HomePage(driver);
                WK.UITest.CanadaPageModels.VideoLibraryPage objVideoLibraryPage = new WK.UITest.CanadaPageModels.VideoLibraryPage(driver);


                objHomePage.clickOnKnowledgeBaseMenu();
                Thread.Sleep(2000);

                objHomePage.clickOnVideoTutorials();
                Thread.Sleep(2000);

                objHomePage.clickOnMinimizeChat();
                Thread.Sleep(2000);

                objHomePage.clickOnLanguageDropdown();
                Thread.Sleep(2000);

                objHomePage.selectLanguageFrench();
                Thread.Sleep(4000);

                //Most Viewed

                objVideoLibraryPage.clickOnMostViewed();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                Logger.log.Pass("Checked Most Viewed");
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                //Hot Topics

                objVideoLibraryPage.clickOnHotTopics();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_15();
                Thread.Sleep(2000);

                objVideoLibraryPage.verifyVideo();
                Thread.Sleep(2000);

                Logger.log.Pass("Checked HotTopics");
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_25();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnResultsPerPage();
                Thread.Sleep(2000);

                objVideoLibraryPage.selectResultsPerPage_50();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnMostViewed();
                Thread.Sleep(2000);

                objVideoLibraryPage.clickOnVideo();
                Thread.Sleep(3000);
                Logger.log.Pass("Clicked on First Video Thumbnail");
                Logger.log.Pass("URL " + driver.Url);

                Logger.log.Pass("Checked Hot Topics and Most Viewed Tabs in French Successfully");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Logger.log.Fail(ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }

        /*--------------------- END : Canada OSS Test Cases ---------------------*/
    }
}
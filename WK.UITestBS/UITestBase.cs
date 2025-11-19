using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using Deque.AxeCore.Commons;
using Deque.AxeCore.Selenium;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WK.UITest
{
    /// <summary>
    /// Base class to be inherited in every test script class
    /// </summary>
    [TestClass]

    public class UITestBase
    {
        #region Class Members
        /// <summary>
        /// The logger
        /// </summary>
        protected static ExtentReports logger;
        /// <summary>
        /// The driver
        /// </summary>
        protected static IWebDriver driver;

        public static IConfigurationRoot Configuration= new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        /// <summary>
        /// The URL
        /// </summary>
        protected string url =Configuration["Endpoints:SupportSitePathQA"];
        /// <summary>
        /// The URL
        /// </summary>
        protected string urlML = Configuration["Endpoints:MLSitePathQA"]; 
        /// <summary>
        /// The URL
        /// </summary>
        protected string urlCanada = Configuration["Endpoints:CanadaSitePathQA"];
        /// <summary>
        /// The URL
        /// </summary>
        protected string urlSFS = Configuration["Endpoints:SFSSitePathQA"]; 
        /// <summary>
        /// The ie driver
        /// </summary>
        protected static string ieDriver = Configuration["Drivers:IEDriver"];
        /// <summary>
        /// The driver path
        /// </summary>
        protected static string driverPath = Configuration["Drivers:DriverPath"]; 
        /// <summary>
        /// The chrome driver
        /// </summary>
        protected static string chromeDriver = Configuration["Drivers:ChromeDriver"];

        protected string browserName = Configuration["BrowserName"]; 

        protected static Logger objLogger;
        AxeResult axeResult;

        /// <summary>
        /// The test context instance
        /// </summary>
        private TestContext testContextInstance;

        #endregion

        #region Test Context Property

        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion

        #region Initialize And Cleanup Methods
        /// <summary>
        /// Assembly initialize level operations
        /// </summary>
        /// <param name="_testContext">The _test context.</param>
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext _testContext)
        {
            objLogger = new Logger();
            logger = objLogger.getInstance();

            string env;

            _testContext.FullyQualifiedTestClassName.Contains("WK.UITest.CanadaPortalADA");
            if (_testContext.FullyQualifiedTestClassName.Contains("WK.UITest.CanadaPortalADA"))
            {
                env = CommonActions.GetBetween(Configuration["Endpoints:CanadaSitePathQA"], "support-", ".cch.com");

                logger.AddSystemInfo("Host Name", Configuration["Endpoints:CanadaSitePathQA"]);
                logger.AddSystemInfo("Environment", env.ToUpper());
                logger.AddSystemInfo("User Name", Configuration["Credentials:ExternalUserName_OSS"]);
            }
            else if (_testContext.FullyQualifiedTestClassName.Contains("WK.UITest.MLPortalADA"))
            {
                env = CommonActions.GetBetween(Configuration["Endpoints:MLSitePathQA"], "support-", ".cch.com");

                logger.AddSystemInfo("Host Name", Configuration["Endpoints:MLSitePathQA"]);
                logger.AddSystemInfo("Environment", env.ToUpper());
                logger.AddSystemInfo("User Name", Configuration["Credentials:ExternalUserName_OSS"]);
            }
            else if (_testContext.FullyQualifiedTestClassName.Contains("WK.UITest.WKEmpADA"))
            {
                env = CommonActions.GetBetween(Configuration["Endpoints:MLSitePathQA"], "support-", ".cch.com");

                logger.AddSystemInfo("Host Name", Configuration["Endpoints:MLSitePathQA"]);
                logger.AddSystemInfo("Environment", env.ToUpper());
                logger.AddSystemInfo("User Name", Configuration["Credentials:InternalUserName_OSS"]);
            }
            else if (_testContext.FullyQualifiedTestClassName.Contains("WK.UITest.SFSPortalADA"))
            {
                env = CommonActions.GetBetween(Configuration["Endpoints:SFSSitePathQA"], "support-", ".cch.com");

                logger.AddSystemInfo("Host Name", Configuration["Endpoints:SFSSitePathQA"]);
                logger.AddSystemInfo("Environment", env.ToUpper());
                logger.AddSystemInfo("Client ID", Configuration["Credentials:ExternalClientID_SFS_OSS"]);
                logger.AddSystemInfo("User Name", Configuration["Credentials:ExternalUserName_SFS_OSS"]);
            }
            else if (_testContext.FullyQualifiedTestClassName.Contains("WK.UITest.OneSupportPortalUI"))
            {
                if(_testContext.TestName.StartsWith("ML"))
                {
                    env = CommonActions.GetBetween(Configuration["Endpoints:MLSitePathQA"], "support-", ".cch.com");

                    logger.AddSystemInfo("Host Name", Configuration["Endpoints:MLSitePathQA"]);
                    logger.AddSystemInfo("Environment", env.ToUpper());
                    logger.AddSystemInfo("User Name", Configuration["Credentials:ExternalUserName_OSS"]);
                }
                else if (_testContext.TestName.StartsWith("Canada"))
                {
                    env = CommonActions.GetBetween(Configuration["Endpoints:CanadaSitePathQA"], "support-", ".cch.com");

                    logger.AddSystemInfo("Host Name", Configuration["Endpoints:CanadaSitePathQA"]);
                    logger.AddSystemInfo("Environment", env.ToUpper());
                    logger.AddSystemInfo("User Name", Configuration["Credentials:ExternalUserName_OSS"]);
                }
                else
                {
                    env = CommonActions.GetBetween(Configuration["Endpoints:SFSSitePathQA"], "support-", ".cch.com");

                    logger.AddSystemInfo("Host Name", Configuration["Endpoints:SFSSitePathQA"]);
                    logger.AddSystemInfo("Environment", env.ToUpper());
                    logger.AddSystemInfo("Client ID", Configuration["Credentials:ExternalClientID_SFS_OSS"]);
                    logger.AddSystemInfo("User Name", Configuration["Credentials:ExternalUserName_SFS_OSS"]);
                }
            }
            else
            {
                logger.AddSystemInfo("Host Name", Configuration["Endpoints:SupportSitePathQA"]);
                logger.AddSystemInfo("Environment", "QA");
                logger.AddSystemInfo("User Name", "taasve.supportsiteQA@wolterskluwer.com");
            }
        }

        /// <summary>
        /// Called before every execution of test case
        /// </summary>
        [TestInitialize]
        public virtual void TestInitialize()
        {

        }

        /// <summary>
        /// Cleanup operations with respect to individual test cases
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

        /// <summary>
        /// Assembly cleanup level operations
        /// </summary>
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            logger.Flush();
            //objLogger.LaunchExecutionResultFile();
        }
        #endregion


        /// <summary>
        /// Scan to check for any violations
        /// </summary>
        public int[] Scan(IWebDriver driver, string info)
        {
            int cnt_minor = 0;
            int cnt_moderate = 0;
            int cnt_serious = 0;
            int cnt_critical = 0;

            int cnt_violations = 0;

            axeResult = new AxeBuilder(driver).WithTags("wcag2aa").Analyze();

            cnt_violations = axeResult.Violations.Count();

            if (cnt_violations == 0)
            {
                var parentNode = Logger.log.CreateNode("Violation(s) not found on " + info + "<br/>" +
                                                             "URL : <a href='" + driver.Url + "'>" + driver.Url + "</a>");
            }
            else
            {
                var parentNode = Logger.log.CreateNode("<b>" + cnt_violations + " violation(s) </b>" + "found on " + info + "<br/>" +
                                                                                        "URL : <a href='" + driver.Url + "'>" + driver.Url + "</a>");


                for (int i = 0; i < cnt_violations; i++)
                {
                    #region count as per Impact
                    if (axeResult.Violations[i].Impact == "critical")
                        cnt_critical++;
                    else if (axeResult.Violations[i].Impact == "serious")
                        cnt_serious++;
                    else if (axeResult.Violations[i].Impact == "moderate")
                        cnt_moderate++;
                    else if (axeResult.Violations[i].Impact == "minor")
                        cnt_minor++;

                    #endregion

                    int cnt_violationNodes = axeResult.Violations[i].Nodes.Count();
                    String json = axeResult.Violations[i].ToString();

                    var childNode = parentNode.CreateNode("<b>" + (i + 1) + "</b> violation  out of <b>" + cnt_violations + "</b> violation(s)" + "<br/>" +
                                                            "" + "<br/>" +
                                                            "Impact : " + axeResult.Violations[i].Impact + "<br />" +
                                                            "Id : " + axeResult.Violations[i].Id + "<br />" +
                                                            "Description : " + axeResult.Violations[i].Description + "<br />" +
                                                            "Help : " + axeResult.Violations[i].Help + "<br />" +
                                                            "HelpUrl : <a href='" + axeResult.Violations[i].HelpUrl + "'>" + axeResult.Violations[i].HelpUrl + "</a>");

                    var childChildNode1 = childNode.CreateNode("<b>" + cnt_violationNodes + "  html node(s) </b> and impact is (are) as follows ↓");

                    for (int x = 0; x < cnt_violationNodes; x++)
                    {
                        childChildNode1.Fail("<pre>HTML Node : " + HttpUtility.HtmlEncode(axeResult.Violations[i].Nodes[x].Html) + "<br />" +
                                              "Impact : " + axeResult.Violations[i].Nodes[x].Impact);
                    }
                    //childNode.Fail("<b>------------------ START : details of violation - " + (i + 1) + " ------------------------");
                    //childNode.Fail("<b>------------------ END : details of violation - " + (i + 1) + " ------------------------");

                    //var childChildNode2 = childNode.CreateNode("<b>JSON ↓ </b>" + "<br />" + (MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json)));
                    var childChildNode2 = childNode.CreateNode("<b>JSON ↓ </b>" + "<br />");
                    childChildNode2.Fail(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
                }
            }

            int[] total_violations = { cnt_critical, cnt_serious, cnt_moderate, cnt_minor };
            return total_violations;
        }
    }
}

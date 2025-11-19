using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace WK.UITest
{
    [DeploymentItem(@"extent-config.xml")]
    public class Logger
    {
        public static IConfigurationRoot Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public static ExtentReports logger;
        public ExtentSparkReporter extentSparkReporter;
        public static ExtentTest log;
        public string logReportsPath = Configuration["LogReportsPath"];
        public static string folderPath = "";
        public static string fileName = "";
        public Logger()
        {
            fileName = String.Format(logReportsPath, DateTime.Now);

            //create folder
            folderPath = Path.Combine(fileName, "..");
            Directory.CreateDirectory(folderPath);

            extentSparkReporter = new ExtentSparkReporter(fileName + ".html");
            logger = new ExtentReports();
            logger.AttachReporter(extentSparkReporter);

        }

        public ExtentReports getInstance()
        {
            if (logger == null)
                logger = new ExtentReports();

            return logger;
        }

        public void LaunchExecutionResultFile()
        {
            Thread.Sleep(1000);
            Process.Start(new ProcessStartInfo
            {
                FileName = fileName + ".html",
                UseShellExecute = true
            });
        }
    }
}

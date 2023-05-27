using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Specflow_Framework.Utility
{
    public class ExtentReport
    {
        public static ExtentReports extentReports;
        public static ExtentTest feature;
        public static ExtentTest _scenario;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;   
        public static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("Application", "Youtube");
            extentReports.AddSystemInfo("Browser", "Chrome");
            extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        { 
            extentReports.Flush();  
        }

        public string CaptureScreenshot(IWebDriver driver, ScenarioContext context)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string title = ScenarioContext.Current.ScenarioInfo.Title;
            string screenshotLocation = Path.Combine(testResultPath, title + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }

        }
}

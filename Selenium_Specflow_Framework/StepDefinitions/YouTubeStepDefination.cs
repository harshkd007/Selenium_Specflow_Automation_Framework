using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Specflow_Framework.StepDefinitions
{
    [Binding]
    public sealed class YouTubeStepDefination
    {
        IWebDriver driver;
        [Given(@"Open the chrome browser")]
        public void GivenOpenTheChromeBrowser()
        {
            driver = new ChromeDriver();
        }

        /// <summary>
        /// Step defination for "Enter text and search on youtube"
        /// </summary>
        /// <param name="searchString"></param>
        [When(@"search '([^']*)' on youtube")]
        public void WhenSearchOnYoutube(string searchString)
        {
            driver.Url = "https://www.youtube.com/";
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@name='search_query']")).SendKeys(searchString);
            driver.FindElement(By.XPath("//*[@name='search_query']")).SendKeys(Keys.Enter);// to press the enter key
        }

        /// <summary>
        /// Step defination for "I verify the title"
        /// </summary>
        /// <param name="title"></param>
        [Then(@"I verify the title '([^']*)'")]
        public void ThenIVerifyTheTitle(string title)
        {
            Thread.Sleep(5000);
            Assert.IsTrue(driver.Title.ToUpper().Contains(title.ToUpper()));
        }

        [AfterScenario]
        /// <summary>
        /// Step defination for "I close browser window"
        /// </summary>
        [When(@"I close browser window")]
        public void WhenICloseBrowserWindow()
        {
            driver.Quit();
        }




    }
}

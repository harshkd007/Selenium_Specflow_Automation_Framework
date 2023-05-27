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
        public IWebDriver driver;

        public YouTubeStepDefination(IWebDriver driver)
        {
            this.driver = driver; 
        }


        [Given(@"Open the chrome browser")]
        public void GivenOpenTheChromeBrowser()
        {
           // driver = new ChromeDriver();
        }

        [When(@"I enter the URL")]
        public void WhenIEnterTheURL()
        {
            driver.Url = "https://www.youtube.com/";
            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }


        /// <summary>
        /// Step defination for "Enter text and search on youtube"
        /// </summary>
        /// <param name="searchString"></param>
        [When(@"search '([^']*)' on youtube")]
        public void WhenSearchOnYoutube(string searchString)
        {
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
    }
}

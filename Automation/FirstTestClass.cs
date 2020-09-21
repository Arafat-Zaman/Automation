using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Automation
{
    [TestClass]
    public class FirstTestClass
    {
        [TestMethod]
        public void WikiSearch()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            driver.FindElement(By.Id("searchInput")).SendKeys("Selenium");
            driver.FindElement(By.ClassName("pure-button")).Click();


            driver.Quit();
        }

        [TestMethod]
        public void ChromeMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void FireFoxMethod()
        {
            string ActualResult;
            string ExpectedResult = "Google";
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            ActualResult = driver.Title;

            if (ActualResult.Contains(ExpectedResult))
            {
                Console.WriteLine("Test case passed");
                Assert.IsTrue(true, "Test case passed");
            }
            else
            {
                Console.WriteLine("Test case failed");
            }
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void IEMethod()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            driver.Close();
            driver.Quit();
        }
    }
}

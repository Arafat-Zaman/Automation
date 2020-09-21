using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Automation
{
    [TestClass]
    public class FirstTestClass
    {

        [TestMethod]
        public void TwitterRoundUp()
        {
            IWebDriver driver = new FirefoxDriver();
            try
            {
                
                driver.Navigate().GoToUrl("https://www.twitter.com/login");
                driver.Manage().Window.Maximize();
                driver.FindElement(By.ClassName("r-30o5oer-1niwhzgr-17gur6ar-1yadl64r-deolkfr-homxojr-poiln3r-7cikomr-1ny4l3lr-1inuy60r-utggzxr-vmopo1r-1w50u8qr-1swcuj1r-1dz5y72r-fdjqy7r-13qz1uu")).SendKeys("arafat.iitdu@gmail.com");
                driver.FindElement(By.Name("session[password]")).SendKeys("01912087332");
                driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/main/div/div/div[1]/form/div/div[3]/div/div")).Click();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex.ToString());
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
         }

        [TestMethod]
        public void SelectRadioButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
          
            driver.FindElement(By.Id("u_0_2")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("u_1_2")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("u_1_3")).Click();
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void WikiSearch()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            //driver.FindElement(By.Id("searchInput")).SendKeys("Selenium");
            //driver.FindElement(By.ClassName("pure-button")).Click();
            List<string> CentralLanguages = new List<string>();
            ReadOnlyCollection<IWebElement> langauges = driver.FindElements(By.ClassName("central-featured-lang"));
            foreach(IWebElement language in langauges)
            {
                string lang = language.Text;
                lang = lang.Substring(0, lang.LastIndexOf("\r"));
                CentralLanguages.Add(lang);
                
            }

            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.Id("searchLanguage")));
            selectLanguage.SelectByText("Deutsch");
            selectLanguage.SelectByValue("be");
            selectLanguage.SelectByIndex(0);
            
            #region
            List<string> textofanchors = new List<string>();
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("a"));

            foreach(IWebElement anchor in anchorLists)
            {

               if(anchor.Text.Length>0)
                {
                    textofanchors.Add(anchor.Text);
                }
            }
            string stop = "";
            #endregion
            driver.Close();
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

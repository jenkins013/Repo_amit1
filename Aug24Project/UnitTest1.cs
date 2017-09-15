using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Collections.ObjectModel;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace Aug22Project
{
    [TestClass]
    public class UnitTest1
    {
        InternetExplorerOptions options = new InternetExplorerOptions();

        IWebDriver IEDriver = null;
        [TestInitialize]
        public void initialize()
        {
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            IEDriver = new InternetExplorerDriver(options);

            IEDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            

        }
        [TestMethod]
        public void TestMethod1()
        {
            IEDriver.Navigate().GoToUrl("http://www.amazon.in/");
            explicitWait(IEDriver, "nav-logo");

        }
        public void explicitWait(IWebDriver IEDriver, string value)
        {
            WebDriverWait waitFunc = new WebDriverWait(IEDriver, TimeSpan.FromMinutes(2));

            Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((IWebDriver Web) =>
            {
                IWebElement element = Web.FindElement(By.Id(value));
                Console.WriteLine(Web.FindElement(By.Id(value)).GetAttribute("innerHTML"));
                return element;
            });
            waitFunc.Until(waitForElement);
            //return null;
        }
        [TestCleanup]
        public void Testcleanup()
        {
            IEDriver.Close();
        }
    }
}

using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class PlanningPage
    {
        private IWebDriver webDriver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = " //li[@id = 'tln-nav-1071']")]
        private IWebElement BookAFlightButton;

        public PlanningPage(IWebDriver driver)
        {
            this.webDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public BookAFlightPage GoToBookAFlightPage()
        {
            BookAFlightButton.Click();
            return new BookAFlightPage(webDriver);
        }

        public string GetUrl()
        {
            return this.webDriver.Url;
        }
    }
}

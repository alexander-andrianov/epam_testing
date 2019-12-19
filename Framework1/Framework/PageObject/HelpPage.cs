using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class HelpPage
    {
        private IWebDriver webDriver;
        private WebDriverWait Wait;

        public HelpPage(IWebDriver driver)
        {
            this.webDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public string GetUrl()
        {
            return this.webDriver.Url;
        }
    }
}

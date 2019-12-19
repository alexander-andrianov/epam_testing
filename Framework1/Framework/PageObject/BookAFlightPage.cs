using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;

namespace Framework.PageObject
{
    public class BookAFlightPage
    {
        private IWebDriver webDriver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-originSurrogate']")]
        private IWebElement FlightsOriginSurrogate;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-destinationSurrogate']")]
        private IWebElement FlightsDestinationSurrogate;

        [FindsBy(How = How.XPath, Using = "//button[contains(., 'Find Flights')]")]
        private IWebElement FindFlightsButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='flights-oneway']")]
        private IWebElement OneWayRadioButton;

        public BookAFlightPage(IWebDriver driver)
        {
            this.webDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        
        public BookAFlightPage InputFlightsOriginAndDestinationSurrogate(Route route)
        {
            FlightsOriginSurrogate.Clear();
            FlightsOriginSurrogate.SendKeys(route.OriginSurrogate);
            FlightsDestinationSurrogate.SendKeys(route.DestinationSurrogate);
            return this;
        }

        public BookAFlightPage OneWayRadioButtonClick()
        {
            OneWayRadioButton.Click();
            return this;
        }

        public SelectFlightsPage FindFlightsButtonClick()
        {
            FindFlightsButton.Click();
            return new SelectFlightsPage(webDriver);
        }
    }
}

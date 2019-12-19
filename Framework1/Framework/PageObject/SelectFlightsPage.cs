using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class SelectFlightsPage
    {
        private IWebDriver webDriver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = "//div[@id = 'yui_3_1_2_3_157410097521915646']")]
        private IWebElement PreliminaryPrice;

        [FindsBy(How = How.XPath, Using = "//div[@class='content-holder lead-price']/div/div/div[2]")]
        private IWebElement SelectFlight;

        [FindsBy(How = How.XPath, Using = "//button[@class='booknow button paddingB2C translate wasTranslated']")]
        private IWebElement SelectPrice;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'btn-search']")]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'prices-amount']")]
        private IWebElement CurrentPrice;

        public SelectFlightsPage(IWebDriver driver)
        {
            this.webDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            PageFactory.InitElements(driver, this);
        }

        public string GetPreliminaryPrice()
        {
            return PreliminaryPrice.Text;
        }

        public SelectFlightsPage SelectFlightClick()
        {
            SelectFlight.Click();
            return this;
        }

        public SelectFlightsPage SelectPriceClick()
        {
            SelectPrice.Click();
            return this;
        }

        public SelectFlightsPage ContinueButtonClick()
        {
            ContinueButton.Click();
            return this;
        }

        public string GetCurrentPrice()
        {
            return CurrentPrice.Text;
        }
    }
}

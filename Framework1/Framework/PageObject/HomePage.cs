using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using log4net;
using System.Linq;

namespace Framework.PageObject
{
    public class HomePage
    {
        private IWebDriver webDriver;

        private readonly string Url = "https://www.emirates.com/english/";
        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        [FindsBy(How = How.XPath, Using = "//input[@name = 'ref-id']")]
        private IWebElement BookingReference;

        [FindsBy(How = How.XPath, Using = "//input[@name = 'last-name']")]
        private IWebElement LastName;

        [FindsBy(How = How.XPath, Using = "//button[@id = 'cookieAcceptButton']")]
        private IWebElement CookieAcceptButton;

        [FindsBy(How = How.XPath, Using = "//a[@class = 'cta cta--large cta--primary js-continue-search-flight search-flight__continue--cta ']")]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = "//button[@class = 'cta cta--large cta--primary js-widget-submit js-my-trips-submit-check-in ']")]
        private IWebElement CheckInButton;

        [FindsBy(How = How.XPath, Using = "//button[@class = 'cta cta--large cta--primary js-widget-submit ']")]
        private IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='cta cta--small cta--primary hero__cta ']")]
        private IWebElement LearnMoreButton;

        [FindsBy(How = How.XPath, Using = "//li[@id='tab1']")]
        private IWebElement ManageBookingButton;

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'Flight status')]")]
        private IWebElement FlightStatus;

        [FindsBy(How = How.XPath, Using = "//a[@id='login-nav-link']")]
        private IWebElement LogIn;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'grid__item error-wrapper visible']/div")]
        private IWebElement ErorrForm;

        public HomePage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(Url);
        }

        public HomePage CookieAcceptClick()
        {
            CookieAcceptButton.Click();
            Log.Info("CookieAcceptClick");
            return this;
        }

        public HomePage ManageBookingClick()
        {
            ManageBookingButton.Click();
            Log.Info("ManageBookingClick");
            return this;
        }

        public HomePage SearchButtonClick()
        {
            SearchButton.Click();
            Log.Info("SearchButtonClick");
            return this;
        }

        public HomePage CheckInButtonClick()
        {
            CheckInButton.Click();
            Log.Info("CheckInButtonClick");
            return this;
        }

        public HomePage ContinueButtonClick()
        {
            ContinueButton.Click();
            Log.Info("ContinueButtonClick");
            return this;
        }

        public LogInPage GoToLogInPage()
        {
            LogIn.Click();
            return new LogInPage(webDriver);
        }

        public LearnMorePage GoToLearnMorePage()
        {
            LearnMoreButton.Click();
            Log.Info("Go To LearnPage");
            return new LearnMorePage(webDriver);
        }

        public HomePage GoToFlightStatus()
        {
            FlightStatus.Click();
            return this;
        }

        public string GetAttributeErrorForm()
        {
            return ErorrForm.GetAttribute("style");
        }

        public bool ErrorFormIsEnabled()
        {
            return IfErrorElementExists();
        }

        public HomePage InputLastNameAndBookingReference(User user)
        {
            LastName.SendKeys(user.LastName);
            BookingReference.SendKeys(user.BookingReference);
            return this;
        }

        public bool IfErrorElementExists()
        {
            var elements = webDriver.FindElements(By.XPath("//*[@class = 'grid__item error-wrapper visible']"));
            return (elements.Count >= 1) ? elements.First().Enabled : false;
        }

        public string GetUrl()
        {
            return this.webDriver.Url;
        }
    }
}

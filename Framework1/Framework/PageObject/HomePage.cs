using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using log4net;

namespace Framework.PageObject
{
    public class HomePage
    {
        private IWebDriver webDriver;

        private readonly string Url = "https://www.emirates.com/english/";
        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        [FindsBy(How = How.XPath, Using = "//button[@id = 'cookieAcceptButton']")]
        private IWebElement CookieAcceptButton;

        [FindsBy(How = How.XPath, Using = "//a[@id='login-nav-link']")]
        private IWebElement PlanningButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='cta cta--small cta--primary hero__cta ']")]
        private IWebElement LearnMoreButton;

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'Flight status')]")]
        private IWebElement FlightStatus;

        [FindsBy(How = How.XPath, Using = "//a[@id='login-nav-link']")]
        private IWebElement LogIn;

        [FindsBy(How = How.XPath, Using = "/html/body/div[12]']")]
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

        public PlanningPage GoToPlanningPage()
        {
            PlanningButton.Click();
            Log.Info("PlanningPageButtonClick");
            return new PlanningPage(webDriver);
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
    }
}

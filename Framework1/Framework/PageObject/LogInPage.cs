using System;
using System.Collections.ObjectModel;
using System.Linq;
using Framework.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class LogInPage
    {
        private IWebDriver webDriver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'sso-email']")]
        private IWebElement VelocityNumber;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'sso-password']")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//button[@id = 'login-button']")]
        private IWebElement LogInButton;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'login-error login-form__error']/div")]
        private IWebElement ErrorForm;

        public LogInPage(IWebDriver driver)
        {
            this.webDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public LogInPage InputVelocityNumberAndBookingReference(User user)
        {
            VelocityNumber.SendKeys(user.VelocityNumber);
            Password.SendKeys(user.Password);
            return this;
        }

        public LogInPage LogInButtonClick()
        {
            LogInButton.Click();
            return this;
        }

        public bool ErrorFormIsEnabled()
        {
            return IfErrorElementExists();
        }

        public bool IfErrorElementExists()
        {
            var elements = webDriver.FindElements(By.XPath("//*[@class = 'login-error login-form__error']"));
            return (elements.Count >= 1) ? elements.First().Enabled : false;
        }
    }
}

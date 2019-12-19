using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using Framework.PageObject;
using Framework.Test;
using Framework.Service;
using Framework.Models;
using log4net;

namespace Framework.Test
{
    public class TestClass : CommonConditions
    {
        const string ErrorTextForSearchWithoutEnteringInformation =
            "Please select your destination";

        const string ErrorTextForSearchByEnteringTheWrongBookingReference =
            "Please enter a valid reservation number.";

        const string ErrorTextForCheckFlight =
            "Invalid flight number. Ensure it contains numbers only. For example, 123.";

        const string ErrorTextForCheckIn =
            "Please select your departure city";

        const string HelpPageUrl = "https://www.emirates.com/english/help/";

        const string PlanningPageUrl = "https://www.emirates.com/english/manage-booking/";

        static private ILog Log = LogManager.GetLogger(typeof(TestClass));

        [Test]
        public void CheckHelpPage()
        {
            HelpPage helpPage = new HomePage(Driver)
                .GoToHelpPage();
            Log.Info("CookieAcceptClick");
            Assert.AreEqual(helpPage.GetUrl(), HelpPageUrl);
        }

        [Test]
        public void LogInWithIncorrectInformation()
        {
            UserCreator userCreator = new UserCreator();
            bool enabledErrorForm = new HomePage(Driver)
                .GoToLogInPage()
                .InputVelocityNumberAndBookingReference(userCreator.LastNameVelocityNumberAndPasswordProperties())
                .LogInButtonClick()
                .ErrorFormIsEnabled();
            Assert.IsTrue(enabledErrorForm);
        }
    }
}

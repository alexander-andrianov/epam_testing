using System;
using System.IO;
using Framework.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.PageObject;
using Framework.Driver;
using NUnit.Framework.Interfaces;
using log4net;
using log4net.Config;

namespace Framework.Test
{
    public class CommonConditions: TestListener
    {
        protected IWebDriver Driver;

        [SetUp]
        public void OpenBrowser()
        {
            Driver = DriverSingleton.GetDriver();
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                TestListener.OnTestFailure();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                TestListener.OnTestSuccess();

            DriverSingleton.CloseDriver();
        }
    }
}

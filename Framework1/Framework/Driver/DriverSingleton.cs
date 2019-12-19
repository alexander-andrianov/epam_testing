using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using OpenQA.Selenium.Firefox;

namespace Framework.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver webDriver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if(null == webDriver)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        //EdgeDriverService edgeService = EdgeDriverService.CreateDefaultService(@"B:\WebDrivers");
                        //edgeService.EdgeBinaryPath = @"C:\Program Files\Microsoft Edge\edge.exe";
                        //webDriver = new EdgeDriver(edgeService);
                        break;
                    default:
                        FirefoxDriverService firefoxService = FirefoxDriverService.CreateDefaultService(@"B:\WebDrivers");
                        firefoxService.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                        webDriver = new FirefoxDriver(firefoxService);
                        break;
                }
                webDriver.Manage().Window.Maximize();
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
            return webDriver;
        }

        public static void CloseDriver()
        {
            webDriver.Quit();
            webDriver = null;
        }
    }
}

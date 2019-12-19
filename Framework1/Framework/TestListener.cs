using log4net;
using log4net.Config;
using System;
using System.IO;
using Framework.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.PageObject;
using Framework.Driver;
using NUnit.Framework.Interfaces;

namespace Framework
{
    public class TestListener
    {
        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        public static ILog log
        {
            get { return Log; }
        }
       
        public static void OnTestFailure()
        {
            TakeScreenshotIfTestFails();
            Log.Error("TestFailure");
        }

        public static void OnTestSuccess()
        {
            Log.Info("TestSuccess");
        }

        private static void TakeScreenshotIfTestFails()
        {
            string screenshotFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screenshots";
            Directory.CreateDirectory(screenshotFolder);
            var screen = DriverSingleton.GetDriver().TakeScreenshot();
            screen.SaveAsFile(screenshotFolder + @"\screenshot" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                ScreenshotImageFormat.Png);
        }
    }
}

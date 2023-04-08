using CoreLibrary.Data;
using CoreLibrary.Extras;
using CoreLibrary.Pages;
using CoreLibrary.Pages.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace CoreLibrary.Setup
{
    public class TestSetup
    {

        #region Intializing variables
        protected static IWebDriver DriverInstance { get; set; }
        #endregion

        /// <summary>
        /// Main method that intializes all test-related methods
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {

            switch (ConfigData.TypeOfBrowser)
            {
                case "Chrome":
                    DriverInstance = new ChromeDriver();
                    break;
                case "Firefox":
                    DriverInstance = new FirefoxDriver();
                    break;
            }

            BaseClass.InitializeApplicationPages();

        }

        /// <summary>
        /// Last method to be executed; cleaning up after a test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            DriverInstance.Close();
            DriverInstance.Quit();

        }

        [ClassCleanup]
        public void ClassCleanup()
        {
            DriverInstance.Dispose();
            // Just to be extra sure that the driver is closed...
            // System.Diagnostics.Process.Start("C:/Users/HarisBerilo/Desktop/kill_drivers.bat");
        }

        /// <summary>
        /// Returns driver instance
        /// </summary>
        /// <returns></returns>
        public IWebDriver GetDriver()
        {
            return DriverInstance;
        }


        public static LandingPage OpenWebsite()
        {

            Console.WriteLine("Opening website!");
            DriverInstance.Navigate().GoToUrl("file:///" + ConfigData.FilePathOfApplication);  // TODO: would be better to use relative path
            Console.WriteLine("Navigated to URL!");
            DriverInstance.Manage().Window.Maximize();
            DriverInstance.WaitForPageToLoad();
            Console.WriteLine("Opened page!");

            return LandingPage.GetLandingPage(); // a bit ugly...
        }
    }
}

using CoreLibrary.Extras;
using CoreLibrary.Pages;
using CoreLibrary.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace CoreLibrary.Setup
{
    public class TestSetup
    {

        #region Intializing variables
        /// <summary>
        /// The driver instance
        /// </summary>
        protected static IWebDriver DriverInstance { get; set; }
        /// <summary>
        /// Variable holding all test data
        /// </summary>
        public static Dictionary<string, string> TestData;
        #endregion

        /// <summary>
        /// Main method that intializes all test-related methods
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Initializes all test data in this variable
            //TestData = Extensions.JSONConverter();

            // Decides which browser to use
            switch ("Chrome")
            {
                case "Chrome":
                    DriverInstance = new ChromeDriver();
                    break;
                case "Firefox":
                    DriverInstance = new FirefoxDriver();
                    break;
            }

            // Initializes all pages for POM
            BaseClass.InitializeApplicationPages();
        }

        /// <summary>
        /// Last method to be executed; cleaning up after a test
        /// </summary>
        [TearDown]
        public void TestCleanup()
        {
            DriverInstance.Close();
            DriverInstance.Quit();

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
            DriverInstance.Navigate().GoToUrl("http://localhost:5050");
            Console.WriteLine("Navigated to URL!");
            DriverInstance.Manage().Window.Maximize();
            DriverInstance.WaitForPageToLoad();
            Console.WriteLine("Opened page!");

            return LandingPage.GetLandingPage();
        }
    }
}

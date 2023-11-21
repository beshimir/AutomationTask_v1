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
        #endregion

        /// <summary>
        /// Main method that intializes all test-related methods
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Ideally make this get an environment variable
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
        }

        /// <summary>
        /// Returns driver instance
        /// </summary>
        /// <returns></returns>
        public IWebDriver GetDriver()
        {
            return DriverInstance;
        }

        /// <summary>
        /// Opens the webpage to the appropriate screen
        /// </summary>
        /// <returns></returns>
        public static LandingPage OpenWebsite()
        {
            DriverInstance.Navigate().GoToUrl("http://localhost:5050");
            DriverInstance.Manage().Window.Maximize();
            DriverInstance.WaitForPageToLoad();

            return LandingPage.GetLandingPage();
        }
    }
}

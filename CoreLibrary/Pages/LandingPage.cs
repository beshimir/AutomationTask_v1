using System.Runtime.CompilerServices;
using CoreLibrary.Pages.Base;
using OpenQA.Selenium;
using NUnit.Framework;

namespace CoreLibrary.Pages
{
    public class LandingPage : BaseClass
    {

        #region Locators
        private IWebElement HeadlineLogo => GetElementByXPath("//h1[text()=\"WeShare\"]");
        private IWebElement EmailField => GetElementById("email");
        private IWebElement SubmitField => GetElementById("submit");
        private IWebElement LoggedOutText => GetElementByXPath("//p[contains(text(), \"not logged in\")]");
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////

        #region Navigation/clicking
        /// <summary>
        /// Logs in the desired user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public AllExpensesPage LoginToWebpage(string email)
        {
            EmailField.SendKeys(email);
            SubmitField.Click();

            return AllExpensesPage;
        }
        #endregion

        #region Validation                                                         
        /// <summary>
        /// Asserts that the logo is displayed on the page, if not, throws an error
        /// </summary>
        /// <returns></returns>
        public LandingPage ValidateHeadlineLogoDisplayed()
        {
            Assert.IsTrue(HeadlineLogo.Displayed);

            return this;
        }

        /// <summary>
        /// Validate that the user has been logged out by the displayed text
        /// </summary>
        /// <returns></returns>
        public LandingPage ValidateUserLoggedOut()
        {
            Assert.IsTrue(LoggedOutText.Displayed, "User was not logged out. Check that the text was not changed?");

            return this;
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////


        #region Other methods
        public static LandingPage GetLandingPage() { return LandingPage; }
        #endregion
    }
}

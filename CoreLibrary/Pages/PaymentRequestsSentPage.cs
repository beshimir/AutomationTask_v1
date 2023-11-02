using System.Runtime.CompilerServices;
using CoreLibrary.Pages.Base;
using OpenQA.Selenium;
using NUnit.Framework;

namespace CoreLibrary.Pages
{
    public class PaymentRequestsSentPage : BaseClass
    {
        #region Locators
        private IWebElement PeopleThatOweMeField => GetElementByXPath("//h2[contains(text(), \"People that owe me\")]");
        #endregion

        #region Navigation/clicking
        #endregion

        #region Validation
        /// <summary>
        /// Validates that the Payment requests sent page is opened with the provided text
        /// </summary>
        /// <returns></returns>
        public PaymentRequestsSentPage ValidatePaymentRequestsSentPageOpened()
        {
            Assert.IsTrue(PeopleThatOweMeField.Displayed);

            return this;
        }
        #endregion
    }

}
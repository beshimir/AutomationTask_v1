using System.Runtime.CompilerServices;
using CoreLibrary.Pages.Base;
using OpenQA.Selenium;
using NUnit.Framework;

namespace CoreLibrary.Pages
{
    public class PaymentRequestsReceivedPage : BaseClass
    {
        #region Locators
        private IWebElement PeopleThatYouOweField => GetElementByXPath("//h2[contains(text(), \"People that you owe\")]");
        #endregion

        #region Navigation/clicking
        #endregion

        #region Validation
        /// <summary>
        /// Validates that the Payment requests received page is opened with the text provided
        /// </summary>
        /// <returns></returns>
        public PaymentRequestsReceivedPage ValidatePaymentRequestsReceivedPageOpened()
        {
            Assert.IsTrue(PeopleThatYouOweField.Displayed);

            return this;
        }
        #endregion
    }

}
using CoreLibrary.Pages.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace CoreLibrary.Pages
{
    public class ProductInfoPage : BaseClass
    {

        #region Locators
        private IWebElement SpecificProductID => GetElementById("ProductId");

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////

        #region Navigation/clicking                                                         

        #endregion

        #region Validation
        /// <summary>
        /// Verifies that the appropriate item is displayed
        /// </summary>
        /// <returns></returns>
        public ProductInfoPage VerifySpecificProductDisplayed(string productId)
        {
            if (SpecificProductID.Text == productId)
                Assert.IsTrue(SpecificProductID.Displayed);

            return ProductInfoPage;
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////


        #region Other methods
        public static ProductInfoPage GetProductInfoPage() { return ProductInfoPage; }
        #endregion
    }
}

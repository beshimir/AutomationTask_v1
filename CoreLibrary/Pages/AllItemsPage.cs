using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary.Pages.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace CoreLibrary.Pages
{
    public class AllItemsPage : BaseClass
    {
        #region Locators
        private List<IWebElement> ListOfAllItems => GetElementsByName("ProductIdField");
        private IWebElement SpecificProduct;

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////

        #region Navigation/clicking   
        /// <summary>
        /// Clicks on the supplied product to open it
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductInfoPage ClickOnSpecificProduct(string productId)
        {
            // NOTE: this might not be the most optimal solution
            SpecificProduct = GetElementByXPath($"//input[@value=\"{productId}\"]//following::input");
            if (SpecificProduct.Displayed)
                SpecificProduct.Click();

            return ProductInfoPage;
        }
        #endregion

        #region Validation
        /// <summary>
        /// Verifies that the list of all items is displayed
        /// </summary>
        /// <returns></returns>
        public AllItemsPage VerifyListOfAllItemsDisplayed()
        {
            Assert.IsTrue(!(ListOfAllItems.Count.Equals(0)));

            return AllItemsPage;
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////


        #region Other methods
        public static AllItemsPage GetAllItemsPage() { return AllItemsPage; }
        #endregion
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using CoreLibrary.Pages.Base;

namespace CoreLibrary.Pages
{
    public class LandingPage : BaseClass
    {

        #region Locators
        private IWebElement ListAllItemsButton => GetElementById("ListAllItemsButton");
        private IWebElement SearchBar => GetElementById("ProductIdField");
        private IWebElement FindButton => GetElementById("FindItemButton");
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////

        #region Navigation/clicking                                                         
        public AllItemsPage ClickOnListAllItems()
        {
            if (ListAllItemsButton.Displayed)
                ListAllItemsButton.Click();
            
            return AllItemsPage;
        }

        public ProductInfoPage ClickOnFindButton()
        {
            if (FindButton.Displayed)
                FindButton.Click();

            return ProductInfoPage;
        }
        public LandingPage EnterProductIdIntoSearchBar(string productId)
        {
            if (SearchBar.Displayed)
            {
                SearchBar.Click();
                SearchBar.SendKeys(productId);
            }

            return LandingPage;
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////


        #region Other methods
        public static LandingPage GetLandingPage() { return LandingPage; }
        #endregion
    }
}

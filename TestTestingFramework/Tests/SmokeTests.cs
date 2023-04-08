using CoreLibrary.Data;
using CoreLibrary.Pages.Base;
using CoreLibrary.Setup;


namespace TestTestingFramework.Tests
{
    [TestClass]
    public class SmokeTests : TestSetup
    {
        /// <summary>
        /// User story 1
        /// 
        /// As an administrator of the EHS system I want to be able to see all the available products so that
        /// I can make faster decisions.
        /// </summary>
        [TestMethod]
        public void US_1_TestListOfAllItemsAvailability()
        {

            BaseClass
                .OpenWebsite()
                .ClickOnListAllItems()
                .VerifyListOfAllItemsDisplayed();


        }

        /// <summary>
        /// User story 2
        /// 
        /// As an administrator of the EHS system I want to se detailed information about a specific
        /// product so that I know that the system is up to date.
        /// 
        /// </summary>
        [TestMethod]
        public void US_2_TestProductInfoAvailability()
        {
            // UserStory2ProductID is used as the product in question.
            // Editable in ../../CoreLibrary/Data/ConfigData.cs
            BaseClass
                .OpenWebsite()
                .ClickOnListAllItems()
                .ClickOnSpecificProduct(ConfigData.UserStory2ProductID)
                .VerifySpecificProductDisplayed(ConfigData.UserStory2ProductID);


        }

        /// <summary>
        /// User story 3
        /// 
        /// As an administrator of the EHS system I want to be able to search for a specific product so that
        /// I can get faster access to its product details.
        /// 
        /// </summary>
        [TestMethod]
        public void US_3_TestFindFunctionalityAvailability()
        {
            // UserStory2ProductID is used as the product in question.
            // Editable in ../../CoreLibrary/Data/ConfigData.cs
            BaseClass
                .OpenWebsite()
                .EnterProductIdIntoSearchBar(ConfigData.UserStory3ProductID)
                .ClickOnFindButton()
                .VerifySpecificProductDisplayed(ConfigData.UserStory3ProductID);


        }

    }
}

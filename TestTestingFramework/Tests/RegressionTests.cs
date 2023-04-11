using CoreLibrary.Data;
using CoreLibrary.Pages.Base;
using CoreLibrary.Setup;


namespace TestTestingFramework.Tests
{
    [TestClass]
    public class RegressionTests : TestSetup
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
            Console.WriteLine("Starting 1st User Story!");
            BaseClass
                .OpenWebsite()
                .ClickOnListAllItems()
                .VerifyListOfAllItemsDisplayed();

            Console.WriteLine("Ended test!");
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
            Console.WriteLine("Starting 2nd User Story!");
            // UserStory2ProductID is used as the product in question.
            // Editable in ../../CoreLibrary/Data/ConfigData.cs
            BaseClass
                .OpenWebsite()
                .ClickOnListAllItems()
                .ClickOnSpecificProduct(TestData["US_2_TestID"])
                .VerifySpecificProductDisplayed(TestData["US_2_TestID"]);

            Console.WriteLine("Ended test!");
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
            Console.WriteLine("Starting 3rd User Story!");
            // UserStory3ProductID is used as the product in question.
            // Editable in ../../CoreLibrary/Data/ConfigData.cs
            BaseClass
                .OpenWebsite()
                .EnterProductIdIntoSearchBar(TestData["US_3_TestID"])
                .ClickOnFindButton()
                .VerifySpecificProductDisplayed(TestData["US_3_TestID"]);

            Console.WriteLine("Ended test!");
        }
    }
}

using CoreLibrary.Pages.Base;
using CoreLibrary.Setup;
using NUnit.Framework;


namespace TestTestingFramework.Tests
{
    [TestFixture]
    public class UITests : TestSetup
    {
        /// <summary>
        /// User story 1
        /// </summary>
        [Order(1), TestCase("student1@wethinkcode.co.za"), Description("Validate that the user can log in with a predefined email")]
        public void Test_UserCanLogin(string email)
        {
            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ValidateUserLoggedIn(email);
        }

        /// <summary>
        /// User story 2
        /// </summary>
        [Order(2), TestCase("student1@wethinkcode.co.za"), Description("Validate that a logged in user can log out")]
        public void Test_UserCanLogout(string email) {
            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ValidateUserLoggedIn(email)
                .LogoutFromWebpage()
                .ValidateUserLoggedOut();
        }

        /// <summary>
        /// User story 3
        /// </summary>
        /// <param name="email"></param>
        [Order(3), TestCase("student1@wethinkcode.co.za")]
        public void Test_AddNewExpenseAndVerify(string email) {
            string expense_name = Guid.NewGuid().ToString();
            string date = DateTime.Now.ToString("dd-M-yyyy");
            string date_validationFormat = DateTime.Now.ToString("yyyy-M-dd");
            int amount = 100;

            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ClickOnAddNewExpenseButton()
                .AddNewExpense(expense_name, date, amount)
                .ValidateExpenseExists(expense_name, date_validationFormat, "ZAR " + amount + ".00");
        }

        /// <summary>
        /// User story 4
        /// </summary>
        /// <param name="email"></param>
        [Order(4), TestCase("student1@wethinkcode.co.za")]
        public void Test_AddNewPaymentRequestAndVerify(string email)
        {
            string date = DateTime.Now.ToString("dd-M-yyyy");
            string date_validationFormat = DateTime.Now.ToString("yyyy-M-dd");

            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ClickOnExpenseName("Dinner also")
                .ValidatePaymentRequestFormDisplayed()
                .AddNewPaymentRequest("student3@wethinkcode.co.za", "1", date)
                .ValidatePaymentRequestExists("Student3", "ZAR 1.00", date_validationFormat);
        }

        /// <summary>
        /// User story 5
        /// </summary>
        /// <param name="email"></param>
        [Order(5), TestCase("student1@wethinkcode.co.za")]
        public void Test_OpenSpecificExpense(string email)
        {
            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ClickOnExpenseName("Dinner also")
                .ValidateExpenseName("Dinner also");
        }

        /// <summary>
        /// User story 6
        /// </summary>
        /// <param name="email"></param>
        [Order(6), TestCase("student1@wethinkcode.co.za")]
        public void Test_OpenPaymentRequestsSent(string email)
        {
            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ClickOnPaymentRequestsSent()
                .ValidatePaymentRequestsSentPageOpened();
        }

        /// <summary>
        /// User story 7
        /// </summary>
        /// <param name="email"></param>
        [Order(7), TestCase("student1@wethinkcode.co.za")]
        public void Test_OpenOutgoingPaymentRequests(string email)
        {
            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ClickOnPaymentRequestsReceived()
                .ValidatePaymentRequestsReceivedPageOpened();
        }


    }
}

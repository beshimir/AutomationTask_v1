using CoreLibrary.Pages.Base;
using CoreLibrary.Setup;
using NUnit.Framework;


namespace WeShareTests.Tests
{
    [TestFixture]
    public class UITests : TestSetup
    {
        // General/global data for test
        private string newExpenseName = Guid.NewGuid().ToString();

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
        public void Test_UserCanLogout(string email)
        {
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
        [Order(3), TestCase("student1@wethinkcode.co.za"), Description("Validate that the user can add a new expense, and verify that the expense has been added")]
        public void Test_AddNewExpenseAndVerify(string email) {
            
            // Data for test
            string expense_name = newExpenseName;
            string date = DateTime.Now.ToString("dd/M/yyyy");
            string date_validationFormat = DateTime.Now.ToString("yyyy-M-dd");
            int amount = 100;
            string amount_validationFormat = "ZAR " + amount + ".00";

            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ClickOnAddNewExpenseButton()
                .AddNewExpense(expense_name, date, amount)
                .ValidateExpenseExists(expense_name, date_validationFormat, amount_validationFormat);
        }

        /// <summary>
        /// User story 4
        /// </summary>
        [Order(4), TestCase("student1@wethinkcode.co.za"), Description("Validate that the user can add a new payment request, and verify that the payment request has been added")]
        public void Test_AddNewPaymentRequestAndVerify(string email)
        {
            // Data for test
            string date = DateTime.Now.ToString("dd-M-yyyy");
            string date_validationFormat = DateTime.Now.ToString("yyyy-M-dd");
            string expense_name = newExpenseName;
            string expenseTo_email = "student3@wethinkcode.co.za";
            string expenseTo_email_validationFormat = CoreLibrary.Extras.Extensions.ExtractUsernameFromEmail_API(expenseTo_email);
            int amount = 1;
            string amount_validationFormat = "ZAR " + amount + ".00";

            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ClickOnExpenseName(expense_name)
                .ValidatePaymentRequestFormDisplayed()
                .AddNewPaymentRequest(expenseTo_email, amount, date)
                .ValidatePaymentRequestExists(expenseTo_email_validationFormat, amount_validationFormat, date_validationFormat);
        }

        /// <summary>
        /// User story 5
        /// </summary>
        [Order(5), TestCase("student1@wethinkcode.co.za"), Description("Validate that the user can open an expense based on the expense name")]
        public void Test_OpenSpecificExpense(string email)
        {
            // Data for test
            string expense_name = newExpenseName;
            
            BaseClass
                .OpenWebsite()
                .LoginToWebpage(email)
                .ClickOnExpenseName(expense_name)
                .ValidateExpenseName(expense_name);
        }

        /// <summary>
        /// User story 6
        /// </summary>
        [Order(6), TestCase("student1@wethinkcode.co.za"),  Description("Validate that the user can open the payment requests sent tab and view the payment requests")]
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
        [Order(7), TestCase("student1@wethinkcode.co.za"),  Description("Validate that the user can open the payment requests received tab and view the payment requests")]
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

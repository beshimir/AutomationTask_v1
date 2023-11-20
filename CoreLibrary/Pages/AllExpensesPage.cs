using System.Runtime.CompilerServices;
using CoreLibrary.Pages.Base;
using OpenQA.Selenium;
using NUnit.Framework;

namespace CoreLibrary.Pages
{
    public class AllExpensesPage : BaseClass
    {

        #region Locators
        private IWebElement UserField => GetElementById("user");
        private IWebElement LogoutButton => GetElementById("logout");
        private IWebElement AddNewExpenseButton => GetElementById("add_expense");
        private IList<IWebElement> ListOfExpenses => GetElementsByXPath("//table[@id=\"expenses\"]//tbody//tr");
        private IWebElement PaymentRequestsSentButton => GetElementById("paymentrequests_sent");
        private IWebElement PaymentRequestsReceivedButton => GetElementById("paymentrequests_received");
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////

        #region Navigation/clicking
        /// <summary>
        /// Method which logs the user out
        /// </summary>
        /// <returns></returns>
        public LandingPage LogoutFromWebpage()
        {
            LogoutButton.Click();

            return LandingPage;
        }

        /// <summary>
        /// Method which clicks on the 'Add new expense' button
        /// </summary>
        /// <returns></returns>
        public AddNewExpensePage ClickOnAddNewExpenseButton()
        {
            AddNewExpenseButton.Click();

            return AddNewExpensePage;
        }

        /// <summary>
        /// Clicks on an expense given in the parameters
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ExpenseDetailsPage ClickOnExpenseName(string name)
        {
            IWebElement ExpenseDetailsButton = GetDriver().FindElement(By.XPath($"//a[text()=\"{name}\"]"));
            ExpenseDetailsButton.Click();

            return ExpenseDetailsPage;
        }

        /// <summary>
        /// Method which clicks on the Payment requests sent button
        /// </summary>
        /// <returns></returns>
        public PaymentRequestsSentPage ClickOnPaymentRequestsSent()
        {
            PaymentRequestsSentButton.Click();

            return PaymentRequestsSentPage;
        }

        /// <summary>
        /// Method which clicks on the Payment requests received button
        /// </summary>
        /// <returns></returns>
        public PaymentRequestsReceivedPage ClickOnPaymentRequestsReceived()
        {
            PaymentRequestsReceivedButton.Click();

            return PaymentRequestsReceivedPage;
        }
        #endregion

        #region Validation                      
        /// <summary>
        /// Validates that the currently logged in user is the desired user, throws error if not
        /// </summary>
        /// <param name="user"></param>
        public AllExpensesPage ValidateUserLoggedIn(string user)
        {
            string CurrentlyLoggedInUser = UserField.Text;
            Assert.AreEqual(CurrentlyLoggedInUser, user);
            
            return this;
        }

        /// <summary>
        /// Validate that the expense with the given parameters exists
        /// </summary>
        /// <param name="description">The title of the expense</param>
        /// <param name="date">The date of the expense in YYYY-MM-DD format</param>
        /// <param name="amount">The amount of the expense in 'ZAR $$$.$$' format</param>
        /// <returns></returns>
        public AllExpensesPage ValidateExpenseExists(string description, string date, string amount)
        {
            string actual_description = "";
            string actual_date = "";
            string actual_amount = "";

                // Iterate through each expense and compare the values to the one that needs to be validated
                for(int i = 1; i <= ListOfExpenses.Count; i++)
                {
                    actual_description = GetDriver().FindElement(By.XPath($"(//a[contains(@id, \"payment_request\")])[{i}]")).Text;
                    actual_date = GetDriver().FindElement(By.XPath($"(//td[@class=\"date\"])[{i}]")).Text;
                    actual_amount = GetDriver().FindElement(By.XPath($"(//td[contains(@id, \"amount\")])[{i}]")).Text;
                
                    // Probably a better way of doing this...
                    if (description.Equals(actual_description) && date.Equals(actual_date) && amount.Equals(actual_amount))
                    {
                        Assert.Pass();
                    }
                    else
                        continue;
                }

                // If the function doesnt return anything until here, there is no cooresponding expense.
                Assert.Fail("There is no cooresponding expense.");
            
            return this;
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////


        #region Other methods
        public static AllExpensesPage GetAllExpensesPage() { return AllExpensesPage; }
        #endregion

    }
}
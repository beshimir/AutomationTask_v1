using System.Runtime.CompilerServices;
using CoreLibrary.Pages.Base;
using OpenQA.Selenium;
using NUnit.Framework;

namespace CoreLibrary.Pages
{
    public class ExpenseDetailsPage : BaseClass
    {
        #region Locators
        private IList<IWebElement> PaymentRequestForm => GetElementsById("paymentrequest_form");
        private IWebElement PaymentRequestEmailField => GetElementById("email");
        private IWebElement PaymentRequestAmountField => GetElementById("amount");
        private IWebElement PaymentRequestDueDateField => GetElementById("due_date");
        private IWebElement SubmitButton => GetElementById("submit");
        private IList<IWebElement> ListOfPaymentRequests => GetElementsByXPath("//*[@id=\"paymentrequests\"]//tbody//tr");
        private IWebElement ExpenseName => GetElementById("expense_description");
        #endregion

        #region Navigation/clicking
        /// <summary>
        /// Method which adds a new payment request for the given opened expense.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="amount"></param>
        /// <param name="due_date"></param>
        /// <returns></returns>
        public ExpenseDetailsPage AddNewPaymentRequest(string email, int amount, string due_date)
        {
            PaymentRequestEmailField.SendKeys(email);
            PaymentRequestAmountField.SendKeys(amount.ToString());
            PaymentRequestDueDateField.SendKeys(due_date);
            SubmitButton.Click();

            return this;
        }
        #endregion

        #region Validation
        /// <summary>
        /// Validates that the payment request form is displayed
        /// </summary>
        /// <returns></returns>
        public ExpenseDetailsPage ValidatePaymentRequestFormDisplayed()
        {
            if(PaymentRequestForm.Count == 0)
            {
                Assert.Fail("The payment request form was not displayed. Check if the number of payment requests has been maximized, or some other error.");
            }

            return this;
        }

        /// <summary>
        /// Validates that the payment request with the provided parameters exists
        /// </summary>
        /// <param name="email">Left-hand side of the email provided in the new payment request form with a capitalized first letter ex. Exampleemail</param>
        /// <param name="amount">Amount must be an integer value</param>
        /// <param name="due_date">Due date must be in format yyyy-MM-dd</param>
        /// <returns></returns>
        public ExpenseDetailsPage ValidatePaymentRequestExists(string email, string amount, string due_date)
        {
            string actual_email = "";
            string actual_amount = "";
            string actual_due_date = "";

            foreach(IWebElement expense in ListOfPaymentRequests)
            {
                try
                {
                    actual_email = expense.FindElement(By.XPath("//td[contains(@id, \"paymentrequest_who\")]")).Text;
                    actual_due_date = expense.FindElement(By.XPath("//td[contains(@id, \"paymentrequest_date\")]")).Text;
                    actual_amount = expense.FindElement(By.XPath("//td[contains(@id, \"paymentrequest_amount\")]")).Text;
                    
                    Assert.AreEqual(email.ToLower(), actual_email.ToLower(), "Expense email is not equal.");
                    Assert.AreEqual(amount, actual_amount, "Expense amount is not equal.");
                    Assert.AreEqual(due_date, actual_due_date, "Expense dates are not equal.");

                    break;
                }
                catch (Exception)
                {
                    continue;
                }
                finally
                {
                    Assert.Fail("No appropriate payment request was found.");
                }
            }

            return this;
        }

        /// <summary>
        /// Validate that the expense name in the parameters is displayed on the page
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ExpenseDetailsPage ValidateExpenseName(string name)
        {
            Assert.IsTrue(ExpenseName.Displayed);

            return this;
        }
        #endregion
    }
}
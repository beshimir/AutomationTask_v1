using System.Runtime.CompilerServices;
using CoreLibrary.Pages.Base;
using OpenQA.Selenium;
using NUnit.Framework;

namespace CoreLibrary.Pages
{
    public class AddNewExpensePage : BaseClass
    {
        #region Locators
        private IWebElement ExpenseDescriptionField => GetElementById("description");
        private IWebElement ExpenseDateField => GetElementById("date");
        private IWebElement ExpenseAmountField => GetElementById("amount");
        private IWebElement SubmitButton => GetElementById("submit");
        #endregion

        #region Navigation/clicking
        /// <summary>
        /// Create a new expense by entering the appropriate parameters and click Submit.
        /// </summary>
        /// <param name="description">Any alphanumeric combination of characters</param>
        /// <param name="date">Date in the format dd-M-yyyy</param>
        /// <param name="amount">Amount as a non-negative integer</param>
        /// <returns></returns>
        public AllExpensesPage AddNewExpense(string description, string date, int amount)
        {
            ExpenseDescriptionField.SendKeys(description);
            ExpenseDateField.SendKeys(date);
            ExpenseAmountField.SendKeys(amount.ToString());
            SubmitButton.Click();

            return AllExpensesPage;
        }
        #endregion

        #region Validation
        
        #endregion
    }

}
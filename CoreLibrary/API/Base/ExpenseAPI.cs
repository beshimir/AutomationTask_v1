using RestSharp;
using CoreLibrary.Models.Base;
using Newtonsoft.Json;
using NUnit.Framework;
using CoreLibrary.Extras;
using CoreLibrary.Models.DTO;

namespace CoreLibrary.API
{
    public class ExpenseAPI
    {
        private static string BasePage = "http://localhost:5050";
        private static RestClient Client = new RestClient(BasePage);

        /// <summary>
        /// Method which performs a GET request to the appropriate endpoint, retrieves and returns a list of all the expenses
        /// </summary>
        /// <returns></returns>
        public static List<Expense> GetAllExpenses()
        {
            RestRequest request = new RestRequest("/api/expenses", Method.Get);
            RestResponse response = Client.Execute(request);

            List<Expense> listOfAllExpenses = JsonConvert.DeserializeObject<List<Expense>>(response.Content);

            // In case the response could not be retrieved, display an appropriate message.
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "The list could not be retrieved. Status code: " + (int)response.StatusCode);

            return listOfAllExpenses;
        }


        /// <summary>
        /// Method which performs a GET request to the appropriate endpoint, retrieves and returns a list of all expenses for a particular person (by their id)
        /// </summary>
        /// <param name="id">Id of person (can be obtained by getting all persons)</param>
        public static List<Expense> GetExpensesByPersonId(int id)
        {
            RestRequest request = new RestRequest($"/api/expenses/person/{id}", Method.Get);
            RestResponse response = Client.Execute(request);

            List<Expense> listOfExpensesForPerson = JsonConvert.DeserializeObject<List<Expense>>(response.Content);

            // In case the response could not be retrieved, display an appropriate message.
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "The list could not be retrieved. Status code: " + (int)response.StatusCode);

            return listOfExpensesForPerson;
        }

        /// <summary>
        /// Method which performs a POST request to the appropriate endpoint, creates a new expense for the given person and returns the appropriate detailed expense record
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        public static Expense AddNewExpenseForPerson(ExpenseDTO expense)
        {
            RestRequest request = new RestRequest($"/api/expenses", Method.Post);
            var requestBody = JsonConvert.SerializeObject(expense);

            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            request.AddHeader("Content-Type","application/json");
            
            RestResponse response = Client.Execute(request);

            // The response will be an extended form of the ExpenseDTO model, named Expense, with some additional fields related to payment requests
            Expense response_expense = JsonConvert.DeserializeObject<Expense>(response.Content);

            // Just check if the reponse has successfully returned a 201 Created status code
            Assert.That((int)response.StatusCode, Is.EqualTo(201), "The expense could not be created. Status code: " + (int)response.StatusCode);
        
            return response_expense;
        }
    }
}
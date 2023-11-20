using CoreLibrary.Setup;
using CoreLibrary.Models.DTO;
using CoreLibrary.Models.Base;
using NUnit.Framework;
using CoreLibrary.API;

namespace TestTestingFramework.Tests
{
    public class APITests : TestSetup
    {        
        /// <summary>
        /// Variable holding all test data
        /// </summary>
        public static Dictionary<string, dynamic> TestData = new Dictionary<string, dynamic>();

        /// <summary>
        /// Test case 1
        /// </summary>
        [Order(1)]
        [Test,  Description("Validate that the user can fetch the list of all expenses")]
        public void API_GetAllExpenses() 
        {
            var response = ExpenseAPI.GetAllExpenses();
            
            // Assert that the resposne gotten is a list of expenses -> if not, display approrpiate message
            Assert.That(response, Is.TypeOf<List<Expense>>(), "The reponse is not a list of expenses.");
        }

        /// <summary>
        /// Test case 2
        /// </summary>
        [Order(2)]
        [Test,  Description("Validate that the user can fetch the list of all users")]
        public void API_GetAllUsers()
        {
            var response = PersonAPI.GetAllUsers();

            // Assert that the resposne gotten is a list of people -> if not, display approrpiate message
            Assert.That(response, Is.TypeOf<List<Person>>(), "The reponse is not a list of people.");
        }

        /// <summary>
        /// Test case 3
        /// </summary>
        [Order(3)]
        [Test,  Description("Validate that the user can fetch the list of all payment requests")]
        public void API_GetAllPaymentRequests()
        {
            var response = PaymentRequestAPI.GetAllPaymentRequests();

            // Assert that the resposne gotten is a list of payment requests -> if not, display approrpiate message
            Assert.That(response, Is.TypeOf<List<PaymentRequest>>(), "The reponse is not a list of people.");
        }

        /// <summary>
        /// Test case 4
        /// </summary>
        [Order(4)]
        [Test,  Description("Validate that the user can fetch the list of all expenses tied to a person, by their id")]
        public void API_GetExpenseByPersonId()
        {
            // Setting data that will be used in the test
            int personId = 2;
            var response = ExpenseAPI.GetExpensesByPersonId(personId);

            // Assert that the resposne gotten is a list of expenses -> if not, display approrpiate message
            Assert.That(response, Is.TypeOf<List<Expense>>(), "The reponse is not a list of expenses.");
        }

        /// <summary>
        /// Test case 5
        /// </summary>
        [Order(5)]
        [Test,  Description("Validate that the user can fetch the list of all payment requests sent by a person id")]
        public void API_GetAllPaymentRequestsSentByPersonId()
        {
            // Setting data that will be used in the test
            int personId = 2;
            var response = PaymentRequestAPI.GetPaymentRequestsSentByPersonId(personId);

            // Assert that the response gotten is a list of payment requests -> if not, display appropriate message
            Assert.That(response, Is.TypeOf<List<PaymentRequest>>(), "The reponse is not a list of payment requests.");
        }

        /// <summary>
        /// Test case 6
        /// </summary>
        [Order(6)]
        [Test,  Description("Validate that the user can fetch the list of all payment requests received by a person id")]
        public void API_GetAllPaymentRequestsReceivedByPersonId()
        {
            // Setting data that will be used in the test
            int personId = 2;
            var response = PaymentRequestAPI.GetPaymentRequestsReceivedByPersonId(personId);

            // Assert that the response gotten is a list of payment requests -> if not, display appropriate message
            Assert.That(response, Is.TypeOf<List<PaymentRequest>>(), "The reponse is not a list of payment requests.");
        }

        /// <summary>
        /// Test case 7
        /// </summary>
        [Order(7)]
        [Test,  Description("Validate that the user can fetch the list of all payments by a person id")]
        public void API_GetAllPaymentsByPersonId()
        {
            // Setting data that will be used in the test
            int personId = 2;
            var response = PaymentAPI.GetPaymentsByPersonId(personId);

            // Assert that the response gotten is a list of payment requests -> if not, display appropriate message
            Assert.That(response, Is.TypeOf<List<Payment>>(), "The reponse is not a list of payments.");
        }

    	/// <summary>
        /// Test case 8
        /// </summary>
        [Order(8)]
        [Test,  Description("Validate that the user can add a new user, and verify that the user has been created")]
        public void API_AddNewUser()
        {
            // Define the data of the new person
            string email = Guid.NewGuid().ToString() + "@test.com";

            PersonDTO newPerson = new PersonDTO(email);

            // Send the API request and execute
            var response = PersonAPI.AddNewUser(newPerson);

            // Assert that the resposne gotten is the newly created expense -> if not, display approrpiate message
            Assert.That(response, Is.TypeOf<Person>(), "The response is not a person.");

            // Setting data for further tests
            TestData.Add("newPersonId", response.id);
        }

        /// <summary>
        /// Test case 9
        /// </summary>
        [Order(9)]
        [Test,  Description("Validate that the user can add a new expense, and get the appropriate response")]
        public void API_AddNewExpense()
        {
            // Define the data of the new expense
            int personId = TestData["newPersonId"];
            string date = DateTime.UtcNow.ToString("dd/M/yyyy");
            string description = Guid.NewGuid().ToString();
            int amount = 200;

            ExpenseDTO newExpense = new ExpenseDTO(personId, date, description, amount);

            // Send the API request and execute
            var response = ExpenseAPI.AddNewExpenseForPerson(newExpense);

            // Assert that the resposne gotten is the newly created expense -> if not, display approrpiate message
            Assert.That(response, Is.TypeOf<Expense>(), "The reponse is not a an expense.");

            // Setting values for further tests
            TestData.Add("newExpenseId", response.expenseId);
        }

        /// <summary>
        /// Test case 10
        /// </summary>
        [Order(10)]
        [Test,  Description("Validate that the user can add a new payment request, and verify that the appropriate response is returned")]
        public void API_AddNewPaymentRequest()
        {
            // Define the data of the new payment request
            // NOTE: Be careful with the test data - the appropriate fields must exist already in the db.
            int expenseId = TestData["newExpenseId"];
            int fromPersonId = TestData["newPersonId"];
            int toPersonId = 1;
            string date = DateTime.UtcNow.ToString("dd/M/yyyy");
            int amount = 1;

            PaymentRequestDTO newPaymentRequest = new PaymentRequestDTO(expenseId, fromPersonId, toPersonId, date, amount);

            // Send the API request and execute
            var response = PaymentRequestAPI.AddNewPaymentRequest(newPaymentRequest);

            // Assert that the resposne gotten is the newly created expense -> if not, display approrpiate message
            Assert.That(response, Is.TypeOf<PaymentRequest>(), "The response is not a payment request.");

            // Setting data for further tests
            TestData.Add("newPaymentRequestId", response.id);
        }

        /// <summary>
        /// Test case 11
        /// </summary>
        [Order(11)]
        [Test,  Description("Validate that the user can pay an existing payment request")]
        public void API_PayAnExistingPaymentRequest() 
        {
            // Define the data of the new payment
            // NOTE: Be careful with the test data - the appropriate fields must exist already in the db.
            int expenseId = TestData["newExpenseId"];
            int paymentRequestId = TestData["newPaymentRequestId"];
            int payingPersonId = 1;

            PaymentDTO newPayment = new PaymentDTO(expenseId, paymentRequestId, payingPersonId);

            // Send the API request and execute
            var response = PaymentAPI.PayExistingPaymentRequest(newPayment);

            // Assert that the resposne gotten is the newly created expense -> if not, display approrpiate message
            Assert.That(response, Is.TypeOf<Payment>(), "The response is not a valid payment.");
        }
    }
}
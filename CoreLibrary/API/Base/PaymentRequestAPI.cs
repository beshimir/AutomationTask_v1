using RestSharp;
using CoreLibrary.Models.Base;
using Newtonsoft.Json;
using NUnit.Framework;
using CoreLibrary.Extras;
using CoreLibrary.Models.DTO;

namespace CoreLibrary.API
{
    public class PaymentRequestAPI
    {
        private static string BasePage = "http://localhost:5050";
        private static RestClient Client = new RestClient(BasePage);

        /// <summary>
        /// Method which performs a GET request to the given endpoint and returns the list off all payment requests in the database
        /// </summary>
        /// <returns></returns>
        public static List<PaymentRequest> GetAllPaymentRequests()
        {
            RestRequest request = new RestRequest("/api/paymentrequests", Method.Get);
            RestResponse response = Client.Execute(request);

            List<PaymentRequest> listOfAllPaymentRequests = JsonConvert.DeserializeObject<List<PaymentRequest>>(response.Content);

            // In case the response could not be retrieved, display an appropriate message.
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "The list could not be retrieved. Status code: " + (int)response.StatusCode);

            return listOfAllPaymentRequests;
        }

        /// <summary>
        /// Method which performs a POST request to the appropriate endpoint, creates a new payment request for the given expense and returns the appropriate detailed payment request record
        /// </summary>
        /// <param name="newPaymentRequest"></param>
        /// <returns></returns>
        public static PaymentRequest AddNewPaymentRequest(PaymentRequestDTO newPaymentRequest)
        {
            RestRequest request = new RestRequest($"/api/paymentrequests", Method.Post);
            var requestBody = JsonConvert.SerializeObject(newPaymentRequest);

            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            request.AddHeader("Content-Type","application/json");
            
            RestResponse response = Client.Execute(request);

            // The response will be an extended form of the ExpenseDTO model, named Expense, with some additional fields related to payment requests
            PaymentRequest response_paymentRequest = JsonConvert.DeserializeObject<PaymentRequest>(response.Content);

            // Just check if the reponse has successfully returned a 201 Created status code
            Assert.That((int)response.StatusCode, Is.EqualTo(201), "The payment request could not be created. Status code: " + (int)response.StatusCode);
        
            return response_paymentRequest;
        }

        /// <summary>
        /// Method which performs a GET request to the appropriate endpoint, and fetches the list of all payment requests sent, tied to the given person id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public static List<PaymentRequest> GetPaymentRequestsSentByPersonId(int personId)
        {
            RestRequest request = new RestRequest($"/api/paymentrequests/sent/{personId}", Method.Get);
            RestResponse response = Client.Execute(request);

            List<PaymentRequest> listOfAllPaymentRequestsSent = JsonConvert.DeserializeObject<List<PaymentRequest>>(response.Content);

            // In case the response could not be retrieved, display an appropriate message.
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "The list could not be retrieved. Status code: " + (int)response.StatusCode);

            return listOfAllPaymentRequestsSent;
        }

        /// <summary>
        /// Method which performs a GET request to the appropriate endpoint, and fetches the list of all payment requests received, tied to the given person id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public static List<PaymentRequest> GetPaymentRequestsReceivedByPersonId(int personId)
        {
            RestRequest request = new RestRequest($"/api/paymentrequests/received/{personId}", Method.Get);
            RestResponse response = Client.Execute(request);

            List<PaymentRequest> listOfAllPaymentRequestsReceived = JsonConvert.DeserializeObject<List<PaymentRequest>>(response.Content);

            // In case the response could not be retrieved, display an appropriate message.
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "The list could not be retrieved. Status code: " + (int)response.StatusCode);

            return listOfAllPaymentRequestsReceived;
        }
    }
}
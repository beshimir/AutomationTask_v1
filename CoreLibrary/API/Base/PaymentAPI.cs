using RestSharp;
using CoreLibrary.Models.Base;
using Newtonsoft.Json;
using NUnit.Framework;
using CoreLibrary.Extras;
using CoreLibrary.Models.DTO;
using OpenQA.Selenium.Remote;

namespace CoreLibrary.API
{
    public class PaymentAPI
    {
        private static string BasePage = "http://localhost:5050";
        private static RestClient Client = new RestClient(BasePage);

        /// <summary>
        /// Method which performs a POST request to the appropriate endpoint, creates a new payment for the given expense and returns the appropriate detailed payment record
        /// </summary>
        /// <param name="newPayment"></param>
        /// <returns></returns>
        public static Payment PayExistingPaymentRequest(PaymentDTO newPayment)
        {
            RestRequest request = new RestRequest($"/api/payments", Method.Post);
            var requestBody = JsonConvert.SerializeObject(newPayment);

            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            request.AddHeader("Content-Type","application/json");
            
            RestResponse response = Client.Execute(request);

            // The response will be an extended form of the PaymentDTO model, named Payment, with some additional fields related to payment requests
            Payment response_payment = JsonConvert.DeserializeObject<Payment>(response.Content);

            // Just check if the reponse has successfully returned a 201 Created status code
            Assert.That((int)response.StatusCode, Is.EqualTo(201), "The payment could not be made. Status code: " + (int)response.StatusCode);

            return response_payment;
        }

        /// <summary>
        /// Method which performs a GET request to the appropriate endpoint, and gets all the payments associated with the given person id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public static List<Payment> GetPaymentsByPersonId(int personId)
        {
            RestRequest request = new RestRequest($"/api/payments/madeby/{personId}", Method.Get);
            RestResponse response = Client.Execute(request);

            List<Payment> listOfPaymentsForPerson = JsonConvert.DeserializeObject<List<Payment>>(response.Content);

            // In case the response could not be retrieved, display an appropriate message.
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "The list could not be retrieved. Status code: " + (int)response.StatusCode);

            return listOfPaymentsForPerson;
        }
    }
}
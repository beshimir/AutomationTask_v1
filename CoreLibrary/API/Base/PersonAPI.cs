using RestSharp;
using CoreLibrary.Models.Base;
using Newtonsoft.Json;
using NUnit.Framework;
using CoreLibrary.Extras;
using CoreLibrary.Models.DTO;

namespace CoreLibrary.API
{
    public class PersonAPI
    {
        private static string BasePage = "http://localhost:5050";
        private static RestClient Client = new RestClient(BasePage);

        /// <summary>
        /// Method which returns the list of all users by performing a GET request to the people api endpoint
        /// </summary>
        /// <returns></returns>
        public static List<Person> GetAllUsers()
        {
            RestRequest request = new RestRequest("/api/people", Method.Get);
            RestResponse response = Client.Execute(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "The list could not be retrieved. Status code: " + (int)response.StatusCode);

            var listOfPersons = JsonConvert.DeserializeObject<List<Person>>(response.Content);

            return listOfPersons;
        }

        /// <summary>
        /// Method which performs a POST request to the appropriate endpoint, creates a new user and returns the appropriate detailed user record
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Person AddNewUser(PersonDTO user)
        {
            RestRequest request = new RestRequest("/api/people", Method.Post);
            var requestBody = JsonConvert.SerializeObject(user);

            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            request.AddHeader("Content-Type","application/json");

            RestResponse response = Client.Execute(request);

            var newUser = JsonConvert.DeserializeObject<Person>(response.Content);

            return newUser;
        }
    }
}









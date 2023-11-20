using RestSharp;
using CoreLibrary.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using CoreLibrary.Extras;

namespace CoreLibrary.Models.Base
{
    public class Person
    {
        public string email { get; set; }
        public int id { get; set; }

        public Person(string email, int id)
        {
            this.email = email;
            this.id = id;
        }

        public string GetEmail()
        {
            return email;
        }

        public int GetId()
        {
            return id;
        }
    }
}









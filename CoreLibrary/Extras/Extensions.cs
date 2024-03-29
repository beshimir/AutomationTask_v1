﻿using System.Reflection.PortableExecutable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreLibrary.Extras
{
    public static class Extensions
    {
        /// <summary>
        /// Waits until JS says that page is ready, that is until document.readyState is "complete"
        /// </summary>
        /// <param name="browser">Browser driver</param>
        /// <param name="timeout">Timeout in seconds</param>
        public static void WaitForPageToLoad(this IWebDriver browser, int timeout = 10)
        {
            IWait<IWebDriver> wait = new WebDriverWait(browser, TimeSpan.FromSeconds(timeout));
            wait.Until(driver1 => ((IJavaScriptExecutor)browser).ExecuteScript("return document.readyState;").Equals("complete"));
        }

        /// <summary>
        /// Method which extracts username from email and capitalizes first letter -> as appropriate for API validation
        /// </summary>
        /// <param name="email"></param>
        public static string ExtractUsernameFromEmail_API(string email)
        {
            // Messy...
            string username = email.Substring(0, email.IndexOf("@")-1).ToString();
            username = username[0].ToString().ToUpper() + username.Substring(1);

            return username;
        }
    }
}

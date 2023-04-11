using Newtonsoft.Json;
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


        public static Dictionary<string, string> JSONConverter()
        {
            string filePath = "C:\\Users\\HarisBerilo\\source\\repos\\TestTestingFramework\\CoreLibrary\\Data\\config.json";

            // Read JSON data from file
            string json = File.ReadAllText(filePath);

            Dictionary<string, string> config = new Dictionary<string,string>();
            // Deserialize JSON to C# Dictionary
            config = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            // Access values in the Dictionary
            foreach (var keyValuePair in config)
            {
                Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
            }

            return config;
        }
    }
}

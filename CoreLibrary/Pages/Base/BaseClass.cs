    using OpenQA.Selenium;
    using CoreLibrary.Setup;

    namespace CoreLibrary.Pages.Base
    {
        public class BaseClass : TestSetup
        {
            #region Initializing elements
            protected static LandingPage LandingPage { get; set; }
            protected static AllExpensesPage AllExpensesPage { get; set; }
            protected static AddNewExpensePage AddNewExpensePage { get; set; }  
            protected static ExpenseDetailsPage ExpenseDetailsPage { get; set; }
            protected static PaymentRequestsReceivedPage PaymentRequestsReceivedPage { get; set; }
            protected static PaymentRequestsSentPage PaymentRequestsSentPage { get; set; }
            
        
            /// <summary>
            /// Initializes all pages from the webpage
            /// </summary>
            public static void InitializeApplicationPages()
            {
                LandingPage = new LandingPage();
                AllExpensesPage = new AllExpensesPage();
                AddNewExpensePage = new AddNewExpensePage();
                ExpenseDetailsPage = new ExpenseDetailsPage();   
                PaymentRequestsReceivedPage = new PaymentRequestsReceivedPage();
                PaymentRequestsSentPage = new PaymentRequestsSentPage();
            }

            /// <summary>
            /// Custom method that replaces [FindsBy] decorator
            /// </summary>
            /// <param name="xpath"></param>
            /// <returns></returns>
            public IWebElement GetElementByXPath(string xpath)
            {
                return GetDriver().FindElement(By.XPath(xpath));
            }

            /// <summary>
            /// Custom method that replaces [FindsBy] decorator, but for lists of elements by xpath
            /// </summary>
            /// <param name="xpath"></param>
            /// <returns></returns>
            public List<IWebElement> GetElementsByXPath(string xpath)
            {
                return new List<IWebElement>(GetDriver().FindElements(By.XPath(xpath)));
            }

            /// <summary>
            /// Custom method that replaces [FindsBy] decorator
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public IWebElement GetElementById(string id)
            {
                return GetDriver().FindElement(By.Id(id));
            }

            /// <summary>
            /// Custom method that replaces [FindsBy] decorator
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public List<IWebElement> GetElementsById(string id)
            {
                return new List<IWebElement>(GetDriver().FindElements(By.Id(id)));
            }

            /// <summary>
            /// Custom method that replaces [FindsBy] decorator
            /// </summary>
            /// <param name="css"></param>
            /// <returns></returns>
            public IWebElement GetElementByCss(string css)
            {
                return GetDriver().FindElement(By.CssSelector(css));
            }

            /// <summary>
            /// Custom method that replaces [FindsBy] decorator
            /// </summary>
            /// <param name="css"></param>
            /// <returns></returns>
            public List<IWebElement> GetElementsByCss(string css)
            {
                return new List<IWebElement>(GetDriver().FindElements(By.CssSelector(css)));
            }

            /// <summary>
            /// Custom method that replaces [FindsBy] decorator
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public IWebElement GetElementByName(string name)
            {
                return GetDriver().FindElement(By.Name(name));
            }

            /// <summary>
            /// Custom method that replaces [FindsBy] decorator
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public List<IWebElement> GetElementsByName(string name)
            {
                return new List<IWebElement>(GetDriver().FindElements(By.Name(name)));
            }
        #endregion
    }
}

namespace CoreLibrary.Data
{
    public class ConfigData
    {
        private static string typeOfBrowser = "Firefox";
        private static string filePathOfApplication = "C:\\Users\\HarisBerilo\\source\\repos\\TestTestingFramework\\Website\\Application\\EHS.html";
        private static string userStory2ProductID = "STD 3";
        private static string userStory3ProductID = "STD 1";
        /// <summary>
        /// Variable indicating the browser to be used
        /// </summary>
        public static string TypeOfBrowser
        {
            get { return typeOfBrowser; }
            set { typeOfBrowser = value; }
        }

        // TODO: make this a relative path
        /// <summary>
        /// File path of the application's main html file
        /// </summary>
        public static string FilePathOfApplication
        {
            get { return filePathOfApplication; }
            set { filePathOfApplication = value; }
        }

        /// <summary>
        /// The specified product ID for User Story 2's test
        /// </summary>
        public static string UserStory2ProductID
        {
            get { return userStory2ProductID; }
            set { userStory2ProductID = value; }
        }

        /// <summary>
        /// The specified product ID for User Story 3's test
        /// </summary>
        public static string UserStory3ProductID
        {
            get { return userStory3ProductID; }
            set { userStory3ProductID = value; }
        }
    }
}

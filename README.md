# TestTestingFramework

## Description
My proposed framework with appropriate tests for the given task.

## Note about task
I did not understand the paragraph in the description, quote: 
> * "Important: Do not implement the test tool itself, only the tests and their supporting
framework. Use the API supplied for reference on what methods are available." * 

As it would have been nearly impossible to implement some testing methods using only Exists, Read, Write etc. without knowing how they work in detail.

## Note about proposed solutions
There are many things to improve in this, but I would like to list some improvements I would've liked to make if more time was available:
- Instead of using the Data/ConfigData class for handling test data, a class to parse JSON to actual data would have been more useful.
- ChromeDriver did not work for me in particular on my machine, so I used Firefox. Implementation would(should) not change significantly if Chrome was used.
- ID and Name elements were fetched where possible, but an XPath was used to fetch the buttons since I could not figure out a more optimal way to make the method reusable/not use text on the page.
- The file path in Data/ConfigData could have been made a relative path to make the solution more portable and flexible.
- Waits could be implemented to make the test execution more visible and error-proof.

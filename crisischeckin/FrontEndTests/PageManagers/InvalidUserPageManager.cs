using FrontEndTests.PageManagers.ElementManagers.LogInElements;
using OpenQA.Selenium;

namespace FrontEndTests.PageManagers
{
    public class InvalidUserPageManager
    {
        private readonly IWebDriver _driver;

        public InvalidUserPageManager(IWebDriver driver)
        {
            _driver = driver;
        }

        public string ValidationErrors
        {
            get
            {
                var validationErrors = new LogInValidationErrors(_driver);
                return validationErrors.Value;
            }
        }
    }
}
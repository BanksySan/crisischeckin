using OpenQA.Selenium;

namespace FrontEndTests.Helpers
{
    public class WebDriverFactory
    {
        public IWebDriver Create<TDriver>() where TDriver : IWebDriver, new()
        {
            var driver = new TDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
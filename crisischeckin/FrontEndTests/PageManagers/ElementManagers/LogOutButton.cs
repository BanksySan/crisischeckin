using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using InvalidElementStateException = FrontEndTests.Exceptions.InvalidElementStateException;

namespace FrontEndTests.PageManagers.ElementManagers
{
    public class LogOutButton : IButton
    {
        private readonly IWebDriver _driver;

        private const string LogoutButtonCssSelector = "#log-off";

        public LogOutButton(IWebDriver driver, IWait<IWebDriver> waitUntil)
        {
            _driver = driver;
            waitUntil.Until(d => d.FindElement(By.CssSelector(LogoutButtonCssSelector)));
        }

        public void Click()
        {
            var element = _driver.FindElement(By.CssSelector(LogoutButtonCssSelector));
            if (element.Enabled && element.Displayed)
            {
                element.Click();
            }
            else
            {
                throw new InvalidElementStateException(
                    element,
                    "Expected visable and enabled",
                    $"{nameof(element.Displayed)}: {element.Displayed}, {nameof(element.Displayed)}: {element.Enabled}");
            }
        }
    }
}
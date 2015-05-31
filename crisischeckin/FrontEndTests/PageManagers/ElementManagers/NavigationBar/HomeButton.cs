using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrontEndTests.PageManagers.ElementManagers.NavigationBar
{
    public class HomeButton : IButton
    {
        private readonly IWebDriver _driver;
        private const string HomeButtonCssSelector = "#home";
        private static readonly By BySelector = By.CssSelector(HomeButtonCssSelector);

        public HomeButton(IWebDriver driver, IWait<IWebDriver> waitUntil)
        {
            _driver = driver;
        }

        public void Click()
        {
            var element = _driver.FindElement(BySelector);
            if (element.Enabled && element.Displayed)
            {
                element.Click();
            }
            else
            {
                throw new InvalidElementStateException(
                    $"Expected Home button visable: true & enabled: true, but was visible: {element.Displayed} & enabled: {element.Enabled} ");
            }
        }

        public bool IsVisable
        {
            get
            {
                var element = _driver.FindElement(BySelector);
                return element.Displayed;
            }
        }

        public bool IsEnabled
        {
            get
            {
                var element = _driver.FindElement(BySelector);
                return element.Enabled;
            }
        }

        public bool Exists
        {
            get
            {
                try
                {
                    _driver.FindElement(BySelector);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
    }
}
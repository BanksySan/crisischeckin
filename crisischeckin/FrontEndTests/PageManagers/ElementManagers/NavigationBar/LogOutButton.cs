using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace FrontEndTests.PageManagers.ElementManagers.NavigationBar
{
    public class LogOutButton : IButton
    {
        private readonly IWebDriver _driver;
        private const string LogoutButtonCssSelector = "#log-off";
        private static readonly By BySelector = By.CssSelector(LogoutButtonCssSelector);

        public LogOutButton(IWebDriver driver, IWait<IWebDriver> waitUntil)
        {
            _driver = driver;
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
                var screenShot = _driver.TakeScreenshot();
                screenShot.SaveAsFile("my-screen-shot.jpg", ImageFormat.Jpeg);

                throw new InvalidElementStateException(
                    $"Expected Home button visable: true & enabled: true, but was visible: {element.Displayed} & enabled: {element.Enabled} ");
            }
        }

        public bool IsVisable
        {
            get
            {
                var element = _driver.FindElement(By.CssSelector(LogoutButtonCssSelector));
                return element.Displayed;
            }
        }

        public bool IsEnabled
        {
            get
            {
                var element = _driver.FindElement(By.CssSelector(LogoutButtonCssSelector));
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
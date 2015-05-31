using FrontEndTests.Helpers;
using OpenQA.Selenium;

namespace FrontEndTests.PageManagers
{
    public class HomePageManager : INavigationBar
    {
        private readonly IWebDriver _driver;

        public HomePageManager(IWebDriver driver)
        {
            _driver = driver;
        }

        public AccountLoginManager NavigateToAsUnauthenticated()
        {
            _driver.Navigate().GoToUrl(Constants.BaseUrl);
            var loginManager = new AccountLoginManager(_driver);
            return loginManager;
        }

        public NavigationBarManager NavigationBar
        {
            get
            {
                var navigationBarManager = new NavigationBarManager(_driver);
                return navigationBarManager;
            }
        }
    }

    public interface INavigationBar
    {
        NavigationBarManager NavigationBar { get; }
    }
}
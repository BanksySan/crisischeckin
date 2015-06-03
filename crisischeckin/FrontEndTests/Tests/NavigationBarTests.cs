using System.Linq;
using FrontEndTests.Exceptions;
using FrontEndTests.Helpers;
using FrontEndTests.PageManagers;
using FrontEndTests.PageManagers.ElementManagers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace FrontEndTests.Tests
{
    [TestFixture(typeof (ChromeDriver), Category = Constants.ChromeDriver)]
    [TestFixture(typeof (InternetExplorerDriver), Category = Constants.IeDriver)]
    [TestFixture(typeof (PhantomJSDriver), Category = Constants.PhantomJsDriver)]
    public class NavigationBarTests<TDriver> where TDriver : IWebDriver, new()
    {
        private readonly IWebDriver _driver;

        public NavigationBarTests()
        {
            _driver = new WebDriverFactory().Create<TDriver>();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            new NavigationBarManager(_driver).LogOut(true);
        }

        [Test]
        public void Unauthenticated_user_only_shown_home_link()
        {
            var homePage = new HomePageManager(_driver);
            var logInPage = homePage.NavigateToAsUnauthenticated();
            var navigationBar = logInPage.NavigationBar;
            var assertionErrors = navigationBar.AssertState(NavigationBarStates.Unauthenticated);

            if (assertionErrors.Any())
            {
                throw new MultipleAssertionException(
                    "Unexpected state of Navigation Bar when user is unauthenticated.", assertionErrors);
            }
        }

        public void Authenticated_as_administrator_shown_correct_links()
        {
            var homePage = new HomePageManager(_driver);
            var logInPage = homePage.NavigateToAsUnauthenticated();
            var navigationBar = logInPage.NavigationBar;
            var assertionErrors = navigationBar.AssertState(NavigationBarStates.Unauthenticated);

            if (assertionErrors.Any())
            {
                throw new MultipleAssertionException(
                    "Unexpected state of Navigation Bar when user is unauthenticated.", assertionErrors);
            }
        }
    }
}
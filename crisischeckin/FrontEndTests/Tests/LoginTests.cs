using System.Drawing;
using System.Windows.Forms;
using FrontEndTests.Helpers;
using FrontEndTests.PageManagers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace FrontEndTests.Tests
{
    [TestFixture(typeof (ChromeDriver), Category = Constants.FrontEnd)]
    [TestFixture(typeof (InternetExplorerDriver), Category = Constants.FrontEnd)]
    internal class LoginTests<TDriver> where TDriver : IWebDriver, new()
    {
        private IWebDriver _driver;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var screen = SystemInformation.VirtualScreen;

            _driver = new TDriver();
            _driver.Manage().Window.Size = new Size(screen.Width/2, screen.Height);
            _driver.Manage().Window.Position = new Point(3*screen.Width/2, 0);
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
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
        public void Administrator_logging_is_redirected_to_disaster_list()
        {
            var homePage = new HomePageManager(_driver);

            var loginPage = homePage.NavigateToAsUnauthenticated();
            loginPage.LogInAdministrator();
        }

        [Test]
        public void Invalid_user_sees_error_message()
        {
            var homepage = new HomePageManager(_driver);
            var loginPage = homepage.NavigateToAsUnauthenticated();
            loginPage.LogInInvalidUser();
        }
    }
}
using FrontEndTests.Helpers;
using FrontEndTests.PageManagers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace FrontEndTests.Tests
{
    [TestFixture(typeof (ChromeDriver), Category = Constants.FrontEnd)]
    [TestFixture(typeof (InternetExplorerDriver), Category = Constants.FrontEnd)]
    [TestFixture(typeof (PhantomJSDriver), Category = Constants.PhantomJsDriver)]
    public class InvalidLoginTests<TDriver> where TDriver : IWebDriver, new()
    {
        private readonly IWebDriver _driver;

        public InvalidLoginTests()
        {
            _driver = new WebDriverFactory().Create<TDriver>();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _driver.Quit();
            _driver.Close();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            new NavigationBarManager(_driver).LogOut(true);
        }
    }
}
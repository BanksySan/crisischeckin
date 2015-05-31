﻿using FrontEndTests.Helpers;
using FrontEndTests.PageManagers;
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
    internal class LoginTests<TDriver> where TDriver : IWebDriver, new()
    {
        private IWebDriver _driver;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _driver = new WebDriverFactory().Create<TDriver>();
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
            var invalidUserPageManager = loginPage.LogInInvalidUser();
            Assert.That(invalidUserPageManager.ValidationErrors,
                Is.EqualTo(@"The username/email or password provided is incorrect."));
        }
    }
}
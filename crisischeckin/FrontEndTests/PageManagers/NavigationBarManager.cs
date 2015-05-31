using System;
using System.Collections.Generic;
using FrontEndTests.PageManagers.ElementManagers;
using FrontEndTests.PageManagers.ElementManagers.NavigationBar;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrontEndTests.PageManagers
{
    public class NavigationBarManager
    {
        private readonly IWebDriver _driver;

        public NavigationBarManager(IWebDriver driver)
        {
            _driver = driver;
        }


        public HomePageManager ClickHomePage()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

            var homeButton = new HomeButton(_driver, wait);

            homeButton.Click();
            return new HomePageManager(_driver);
        }

        public HomePageManager LogOut(bool ignoreElementnotPresent = false)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));

                var logoutButton = new LogOutButton(_driver, wait);
                if (ignoreElementnotPresent && !logoutButton.Exists)
                {
                    return new HomePageManager(_driver);
                }

                logoutButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                if (!ignoreElementnotPresent)
                {
                    throw;
                }
            }

            var homePageManager = new HomePageManager(_driver);
            homePageManager.NavigateToAsUnauthenticated();
            return homePageManager;
        }

        public List<InvalidElementStateException> AssertState(INavigationBarState expectedState)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            var exceptions = new List<InvalidElementStateException>();

            var homeButtonExpectations = expectedState.HomeButton;

            var homeButton = new HomeButton(_driver, wait);

            var homeButtonExists = homeButton.Exists;

            if (homeButtonExists != (expectedState.HomeButton != null))
            {
                exceptions.Add(
                    new InvalidElementStateException(
                        $"Home button expected exists: {homeButtonExpectations == null} but was : {homeButtonExists}"));
            }
            else
            {
                var homeButtonVisable = homeButton.IsVisable;
                var homeButtonEnabled = homeButton.IsEnabled;

                if (homeButtonExpectations.Enabled != homeButtonEnabled)
                {
                    exceptions.Add(
                        new InvalidElementStateException(
                            $"Home button expected enabled: {homeButtonExpectations.Enabled} but was {homeButtonEnabled}."));
                }

                if (homeButtonExpectations.Visable != homeButtonVisable)
                {
                    exceptions.Add(
                        new InvalidElementStateException(
                            $"Home button visable enabled: {homeButtonExpectations.Visable} but was {homeButtonVisable}."));
                }
            }

            return exceptions;
        }
    }
}
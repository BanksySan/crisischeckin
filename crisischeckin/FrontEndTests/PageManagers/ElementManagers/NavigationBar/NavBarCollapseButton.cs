using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace FrontEndTests.PageManagers.ElementManagers.NavigationBar
{
    public class NavBarCollapseButton : IToggleButton
    {
        private readonly IWebDriver _driver;
        private const string NavBarToggleCssSelector = ".navbar-toggle";
        private static readonly By BySelector = By.CssSelector(NavBarToggleCssSelector);

        public NavBarCollapseButton(IWebDriver driver)
        {
            _driver = driver;
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

        public void Click()
        {
            var element = _driver.FindElement(BySelector);
            element.Click();
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


        public bool IsTurnedOn
        {
            get
            {
                var element = _driver.FindElement(BySelector);
                return element.Displayed;
            }
        }
    }
}

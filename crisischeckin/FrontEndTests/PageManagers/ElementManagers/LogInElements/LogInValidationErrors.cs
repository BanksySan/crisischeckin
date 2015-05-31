using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace FrontEndTests.PageManagers.ElementManagers.LogInElements
{
    internal class LogInValidationErrors : ILabel
    {
        private readonly IWebDriver _driver;
        private static readonly By BySelector = By.CssSelector(".validation-summary-errors");

        public LogInValidationErrors(IWebDriver driver)
        {
            _driver = driver;
        }


        public string Value
        {
            get
            {
                var element = _driver.FindElement(BySelector);
                return element.Text;
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
                catch (Exception)
                {
                    return false;
                }

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
    }
}

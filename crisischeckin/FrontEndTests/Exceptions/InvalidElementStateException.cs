using OpenQA.Selenium;

namespace FrontEndTests.Exceptions
{
    public class InvalidElementStateException : OpenQA.Selenium.InvalidElementStateException
    {
        public InvalidElementStateException(IWebElement element, string expectedState, string actualState)
            : base(
                $"Element in invalid state.  '{element}'. Expected state: {expectedState} Actual state: {actualState}")
        {
        }
    }
}
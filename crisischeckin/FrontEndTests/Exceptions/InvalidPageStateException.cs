using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace FrontEndTests.Exceptions
{
    public class InvalidPageStateException : AggregateException
    {
        public InvalidPageStateException(string page, IEnumerable<InvalidElementStateException> elementExceptions)
            : base($"Page '{page}' is in an invalid state.", elementExceptions)
        {
        }
    }
}
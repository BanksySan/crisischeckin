using System;
using System.Collections.Generic;

namespace FrontEndTests.Exceptions
{
    public class MultipleAssertionException : AggregateException
    {
        public MultipleAssertionException(IEnumerable<Exception> exceptions) : base(exceptions)
        {
        }

        public MultipleAssertionException(string message, IEnumerable<Exception> exceptions) : base(message + " (See InnerExceptions for details).", exceptions)
        {
        }
    }
}
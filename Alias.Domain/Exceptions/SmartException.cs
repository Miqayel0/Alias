using System;

namespace Alias.Domain.Exceptions
{
    public class SmartException : ApplicationException
    {
        public SmartException(string message = "Smart Eception was thrown") : base(message)
        {
        }
    }
}

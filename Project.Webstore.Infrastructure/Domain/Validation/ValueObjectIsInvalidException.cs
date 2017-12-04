using System;

namespace Project.Webstore.Infrastructure.Domain.Validation
{
    public class ValueObjectIsInvalidException : Exception
    {
        public ValueObjectIsInvalidException(string message) : base(message)
        {

        }
    }
}

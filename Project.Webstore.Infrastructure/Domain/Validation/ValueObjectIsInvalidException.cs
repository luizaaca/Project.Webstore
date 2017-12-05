using System;

namespace Project.Webstore.Infrastructure.UnitOfWork.Validation
{
    public class ValueObjectIsInvalidException : Exception
    {
        public ValueObjectIsInvalidException(string message) : base(message)
        {

        }
    }
}

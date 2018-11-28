using System;

namespace eShop.Domain.Exceptions
{
    public class DomainException : ArgumentException
    {
        public DomainException(string message) : base(message) {}
    }
}
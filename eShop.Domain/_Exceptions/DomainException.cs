using System;

namespace eShop.Domain._Exceptions
{
    public class DomainException : ArgumentException
    {
        public DomainException(string message) : base(message) {}
    }
}
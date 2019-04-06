using eShop.Domain._Exceptions;
using Xunit;

namespace eShop.Domain.Test._Util
{
    public static class Extension
    {
        public static void WithMessage(this DomainException exception, string expectedMessage)
        {
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
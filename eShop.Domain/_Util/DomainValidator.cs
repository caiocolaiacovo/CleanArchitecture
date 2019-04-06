using eShop.Domain._Exceptions;

namespace eShop.Domain._Util
{
    public class DomainValidator
    {
        public static DomainValidator New()
        {
            return new DomainValidator();
        }

        public DomainValidator When(bool condition, string message)
        {
            if (condition)
                throw new DomainException(message);

            return this;
        }
    }
}
using Bogus;
using eShop.Domain.Entities;

namespace eShop.Domain.Test._Builders
{
    public class CustomerBuilder
    {
        private string _name;
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _country;
        private string _documentNumber;
        private string _email;
        private string _phone;

        private CustomerBuilder()
        {
            var faker = new Faker();

            _name = faker.Name.FullName();
            _streetAddress = faker.Address.StreetAddress();
            _city = faker.Address.City();
            _state = faker.Address.State();
            _zipCode = faker.Address.ZipCode();
            _country = faker.Address.Country();
            _documentNumber = faker.Random.Number(int.MaxValue).ToString();
            _email = faker.Person.Email;
            _phone = faker.Person.Phone;
        }

        public static CustomerBuilder New()
        {
            return new CustomerBuilder();
        }

        public Customer Build()
        {
            return new Customer(
                this._name, 
                this._streetAddress, 
                this._city, 
                this._state, 
                this._zipCode, 
                this._country, 
                this._documentNumber, 
                this._email, 
                this._phone);
        }

        public CustomerBuilder WithName(string name)
        {
            this._name = name;
            return this;
        }

        public CustomerBuilder WithStreetAddress(string streetAddress)
        {
            this._streetAddress = streetAddress;
            return this;
        }
        public CustomerBuilder WithCity(string city)
        {
            this._city = city;
            return this;
        }
        public CustomerBuilder WithState(string state)
        {
            this._state = state;
            return this;
        }
        public CustomerBuilder WithZipCode(string zipCode)
        {
            this._zipCode = zipCode;
            return this;
        }
        public CustomerBuilder WithCountry(string country)
        {
            this._country = country;
            return this;
        }
        public CustomerBuilder WithDocumentNumber(string documentNumber)
        {
            this._documentNumber = documentNumber;
            return this;
        }
        public CustomerBuilder WithEmail(string email)
        {
            this._email = email;
            return this;
        }
        public CustomerBuilder WithPhone(string phone)
        {
            this._phone = phone;
            return this;
        }
    }
}
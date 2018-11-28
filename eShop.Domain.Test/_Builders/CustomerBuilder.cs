using eShop.Domain.Entities;

namespace eShop.Domain.Test._Builders
{
    public class CustomerBuilder
    {
        private string _name = "Caio Colaiacovo Carneiro da Costa";
        private string _streetAddress = "195 Avenida Paulista";
        private string _city = "São Paulo";
        private string _state = "São Paulo";
        private string _zipCode = "12000-000";
        private string _country = "Brazil";
        private string _documentNumber = "111.111.111-11";
        private string _email = "myemail@email.com";
        private string _phone = "+55 11 9999-9999";

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
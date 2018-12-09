using System.Collections.Generic;
using eShop.Domain._Util;

namespace eShop.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public string DocumentNumber { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public virtual ICollection<Order> Orders { get; private set; }

        public Customer(string name, string streetAddress, string city, string state, string zipCode, string country, string documentNumber, string email, string phone)
        {
            DomainValidator.New()
                .When(string.IsNullOrEmpty(name), "Name is required")
                .When(string.IsNullOrEmpty(streetAddress), "Street Address is required")
                .When(string.IsNullOrEmpty(city), "City is required")
                .When(string.IsNullOrEmpty(state), "State is required")
                .When(string.IsNullOrEmpty(zipCode), "Zip Code is required")
                .When(string.IsNullOrEmpty(country), "Country is required")
                .When(string.IsNullOrEmpty(documentNumber), "Document Number is required")
                .When(string.IsNullOrEmpty(email), "Email is required")
                .When(string.IsNullOrEmpty(phone), "Phone is required");

            this.Name = name;
            this.StreetAddress = streetAddress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.Country = country;
            this.DocumentNumber = documentNumber;
            this.Email = email;
            this.Phone = phone;

            this.Orders = new List<Order>();
        }
    }
}
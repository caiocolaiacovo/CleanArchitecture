using System;
using Xunit;
using ExpectedObjects;
using eShop.Domain.Entities;
using eShop.Domain.Exceptions;

namespace eShop.Domain.Test
{
    public class CustomerTest
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

        public CustomerTest() { }
        
        [Fact]
        public void Should_Create_A_Customer()
        {
            var expectedCustomer = new {
                Name = _name,
                StreetAddress = _streetAddress,
                City = _city,
                State = _state,
                ZipCode = _zipCode,
                Country = _country,
                DocumentNumber = _documentNumber,
                Email = _email,
                Phone = _phone,
            };

            var customer = new Customer(
                _name, 
                _streetAddress, 
                _city, 
                _state, 
                _zipCode, 
                _country, 
                _documentNumber, 
                _email, 
                _phone);

            expectedCustomer.ToExpectedObject().ShouldMatch(customer);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Name()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                null,
                _streetAddress,
                _city,
                _state,
                _zipCode,
                _country,
                _documentNumber,
                _email,
                _phone
            )).Message;

            Assert.Equal("Nome is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_StreetAddress()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                _name,
                null,
                _city,
                _state,
                _zipCode,
                _country,
                _documentNumber,
                _email,
                _phone
            )).Message;

            Assert.Equal("Street Address is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_City()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                _name,
                _streetAddress,
                null,
                _state,
                _zipCode,
                _country,
                _documentNumber,
                _email,
                _phone
            )).Message;

            Assert.Equal("City is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_State()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                _name,
                _streetAddress,
                _city,
                null,
                _zipCode,
                _country,
                _documentNumber,
                _email,
                _phone
            )).Message;

            Assert.Equal("State is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_ZipCode()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                _name,
                _streetAddress,
                _city,
                _state,
                null,
                _country,
                _documentNumber,
                _email,
                _phone
            )).Message;

            Assert.Equal("Zip Code is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Country()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                _name,
                _streetAddress,
                _city,
                _state,
                _zipCode,
                null,
                _documentNumber,
                _email,
                _phone
            )).Message;

            Assert.Equal("Country is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_DocumentNumber()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                _name,
                _streetAddress,
                _city,
                _state,
                _zipCode,
                _country,
                null,
                _email,
                _phone
            )).Message;

            Assert.Equal("Document Number is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Email()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                _name,
                _streetAddress,
                _city,
                _state,
                _zipCode,
                _country,
                _documentNumber,
                null,
                _phone
            )).Message;

            Assert.Equal("Email is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Phone()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(
                _name,
                _streetAddress,
                _city,
                _state,
                _zipCode,
                _country,
                _documentNumber,
                _email,
                null
            )).Message;

            Assert.Equal("Phone is required", exception);
        }
    }
}

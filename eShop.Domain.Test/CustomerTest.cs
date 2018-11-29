using System;
using Xunit;
using ExpectedObjects;
using eShop.Domain.Entities;
using eShop.Domain.Exceptions;
using Bogus;
using eShop.Domain.Test._Builders;

namespace eShop.Domain.Test
{
    public class CustomerTest
    {
        private Faker faker;

        public CustomerTest() { 
            faker = new Faker();
        }
        
        [Fact]
        public void Should_Create_A_Customer()
        {
            var expectedCustomer = new {
                Name = faker.Name.FullName(),
                StreetAddress = faker.Address.StreetAddress(),
                City = faker.Address.City(),
                State = faker.Address.State(),
                ZipCode = faker.Address.ZipCode(),
                Country = faker.Address.Country(),
                DocumentNumber = faker.Random.Number().ToString(),
                Email = faker.Person.Email,
                Phone = faker.Person.Phone,
            };

            var customer = new Customer(
                expectedCustomer.Name, 
                expectedCustomer.StreetAddress, 
                expectedCustomer.City, 
                expectedCustomer.State, 
                expectedCustomer.ZipCode, 
                expectedCustomer.Country, 
                expectedCustomer.DocumentNumber, 
                expectedCustomer.Email, 
                expectedCustomer.Phone);

            expectedCustomer.ToExpectedObject().ShouldMatch(customer);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Name()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithName(null).Build()).Message;

            Assert.Equal("Name is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_StreetAddress()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithStreetAddress(null).Build()).Message;

            Assert.Equal("Street Address is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_City()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithCity(null).Build()).Message;

            Assert.Equal("City is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_State()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithState(null).Build()).Message;

            Assert.Equal("State is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_ZipCode()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithZipCode(null).Build()).Message;

            Assert.Equal("Zip Code is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Country()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithCountry(null).Build()).Message;

            Assert.Equal("Country is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_DocumentNumber()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithDocumentNumber(null).Build()).Message;

            Assert.Equal("Document Number is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Email()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithEmail(null).Build()).Message;

            Assert.Equal("Email is required", exception);
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Phone()
        {
            var exception = Assert.Throws<DomainException>(() => CustomerBuilder.New().WithPhone(null).Build()).Message;

            Assert.Equal("Phone is required", exception);
        }
    }
}

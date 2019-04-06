using System;
using Xunit;
using ExpectedObjects;
using eShop.Domain.Entities;
using eShop.Domain._Exceptions;
using Bogus;
using eShop.Domain.Test._Builders;
using eShop.Domain.Test._Util;

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
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithName(null).Build())
                .WithMessage("Name is required");
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_StreetAddress()
        {
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithStreetAddress(null).Build())
                .WithMessage("Street Address is required");
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_City()
        {
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithCity(null).Build())
                .WithMessage("City is required");
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_State()
        {
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithState(null).Build())
                .WithMessage("State is required");
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_ZipCode()
        {
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithZipCode(null).Build())
                .WithMessage("Zip Code is required");
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Country()
        {
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithCountry(null).Build())
                .WithMessage("Country is required");
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_DocumentNumber()
        {
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithDocumentNumber(null).Build())
                .WithMessage("Document Number is required");
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Email()
        {
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithEmail(null).Build())
                .WithMessage("Email is required");
        }

        [Fact]
        public void Should_Not_Create_A_Customer_Without_Phone()
        {
            Assert.Throws<DomainException>(() => CustomerBuilder.New().WithPhone(null).Build())
                .WithMessage("Phone is required");
        }
    }
}

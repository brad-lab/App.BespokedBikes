using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace App.BespokedBikes.Domain.Customers
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer _customer;
        private const int Id = 1;
        private const string FirstName = "Test";

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _customer.Id = Id;

            Assert.That(_customer.Id, 
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetFirstName()
        {
            _customer.FirstName = FirstName;

            Assert.That(_customer.FirstName, 
                Is.EqualTo(FirstName));
        }
    }
}

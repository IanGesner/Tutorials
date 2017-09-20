using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo01;

namespace PluralSight.Moq.Tests.Demo01
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            //shows the basic arrange, act, assert pattern
            //shows the simple verification of a method call
            [Test]
            public void the_repository_save_should_be_called()
            {
                //Arrange
                var mockRepository = new Mock<ICustomerRepository>();           //Create new mock repository - allows CustomerService to execute members on it without NullRefExceptions

                mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));        //We expect mockRepository's Save() method to be called with any type of customer object as a parameter

                var customerService = new CustomerService(mockRepository.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());              //Execute SUT

                //Assert
                mockRepository.VerifyAll();                                     //Check and verify all Setup code
            }            
        }
    }
}
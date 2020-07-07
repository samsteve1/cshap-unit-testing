using NUnit.Framework;
using TestNinja.Fundamentals;

namespace PrimeService.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var customerController = new CustomerController();
            var result = customerController.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>()); // strictly type of NotFound
            Assert.That(result, Is.InstanceOf<NotFound>()); // Type of NotFound or its derivative
        }
    }
}
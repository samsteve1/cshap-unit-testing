using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace PrimeService.UnitTests.mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoredTheOrder()
        {
            var mockStorage = new Mock<IStorage>();
            var orderService = new OrderService(mockStorage.Object);
            var order = new Order();

            orderService.PlaceOrder(order);

            mockStorage.Verify(s => s.Store(order));
        }
    }
}
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace PrimeService.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue() // MethodName_Scenario_expectedBehaviour
        {
            // Arrange
            var revervation = new Reservation();
            // Act
            var result = revervation.CanBeCancelledBy(new User { IsAdmin = true });
            // Assert
            Assert.That(result, Is.True);
        }
        [Test]
        public void CanBeCancelledBy_OwnerUserCancelling_ReturnsTrue()
        {
            var user = new User();
            var revervation = new Reservation { MadeBy = user };
            var result = revervation.CanBeCancelledBy(user);
            Assert.That(result, Is.True);
        }
        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            var revervation = new Reservation();
            var result = revervation.CanBeCancelledBy(new User());
            Assert.That(result, Is.False);
        }

    }
}
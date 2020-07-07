using NUnit.Framework;
using TestNinja.Fundamentals;

namespace PrimeService.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue() // MethodName_Scenario_expectedBehaviour
        {
            // Arrange
            var revervation = new Reservation();
            // Act
            var result = revervation.CanBeCancelledBy(new User{IsAdmin = true});
            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void CanBeCancelledBy_UserIsOwner_ReturnsTrue()
        {
            var revervation = new Reservation();
            var user = new User(){IsAdmin = false};
            revervation.MadeBy = user;

            var result = revervation.CanBeCancelledBy(user);
            Assert.IsTrue(result);
        }
        [Test]
        public void CanBeCancelledBy_UserIsNotAdminNorOwner_ReturnsFalse()
        {
            var revervation = new Reservation();
            var result = revervation.CanBeCancelledBy(new User());
            Assert.IsFalse(result);
        }
        
    }
}
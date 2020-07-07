using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace PrimeService.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;
        [SetUp]
        public void Setup()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsInvalid_ThrowArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        [TestCase(1)]
        [TestCase(65)]
        public void CalculateDemeritPoints_SpeedisLessThanOrEqualToSpeedLimit_ReturnsZero(int speed)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void CalculateDemeritPoints_SpeedIsGreaterThanspeedLimit_ReturnDemeritPoints()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(100);

            Assert.That(result, Is.EqualTo(7));
        }
    }
}
using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;
namespace PrimeService.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        // [Ignore("Ignoring this for now!")]
        public void Add_WhenCalled_ReturnsSumOfArguments()
        {
            var result = _math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            // Assert.That(result, Is.Not.Empty);  // Genereic assertion

            // Assert.That(result.Count(), Is.EqualTo(3)); // more specific

            // Assert.That(result, Does.Contain(1)); // more specific
            // Assert.That(result, Does.Contain(2));
            // Assert.That(result, Does.Contain(3));

            Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5})); // not too specific and not generic

            // Assert.That(result, Is.Ordered);
            // Assert.That(result, Is.Unique);
        }
    }
}
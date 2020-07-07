using NUnit.Framework;
using TestNinja.Fundamentals;
namespace PrimeService.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        
        [Test]
        public void Add_WhenCalled_ReturnsSumOfArguments()
        {
            var math = new Math();
            var result =math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void Max_FirstArgumentisGreate_ReturnTheFirstArgument()
        {
            var math = new Math();
            var result = math.Max(2, 1);
            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondargument()
        {
            var math = new Math();
            var result = math.Max(1, 2);
            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void Max_ArgumentsAreTheSame_ReturnTheSameArgument()
        {
            var math = new Math();
            var result = math.Max(1, 1);
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
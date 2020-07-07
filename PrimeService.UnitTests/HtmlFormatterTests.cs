using NUnit.Framework;
using TestNinja.Fundamentals;

namespace PrimeService.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEnclosetheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abc");

            // Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);
            Assert.That(result, Does.Match("<strong>abc</strong>"));
        }
    }
}
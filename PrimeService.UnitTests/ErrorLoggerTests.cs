using NUnit.Framework;
using TestNinja.Fundamentals;

namespace PrimeService.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var errorLogger = new ErrorLogger();
            errorLogger.Log("a");

            Assert.That(errorLogger.LastError, Is.EqualTo("a"));
        }
    }
}
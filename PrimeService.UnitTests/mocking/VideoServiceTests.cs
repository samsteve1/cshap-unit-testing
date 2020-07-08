using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace PrimeService.UnitTests.mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<FakeFileReader> _mockFileReader;
        [SetUp]
        public void SetUp()
        {
            this._mockFileReader = new Mock<FakeFileReader>();
            this._videoService = new VideoService(_mockFileReader.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
           _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
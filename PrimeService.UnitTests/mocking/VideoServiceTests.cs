using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PrimeService.mocking;
using TestNinja.Mocking;

namespace PrimeService.UnitTests.mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _mockFileReader;
        private Mock<IVideoRepository> _mockVideoRepository;
        [SetUp]
        public void SetUp()
        {
            this._mockFileReader = new Mock<IFileReader>();
            this._mockVideoRepository = new Mock<IVideoRepository>();
            this._videoService = new VideoService(_mockFileReader.Object, _mockVideoRepository.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
           _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        [Test]
        public void GetUnProcessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _mockVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_SomeFewVideosAreNotProcessed_ReturnStringWithIdsOfVideos()
        {
            _mockVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video> (){
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3}
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
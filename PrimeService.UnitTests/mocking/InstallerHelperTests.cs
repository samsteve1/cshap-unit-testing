using System.Net;
using Moq;
using NUnit.Framework;
using PrimeService.mocking;
using TestNinja.Mocking;

namespace PrimeService.UnitTests.mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }
        [Test]
        public void DownloadInstaller_DownloadFailed_ReturnFalse()
        {
            _fileDownloader.Setup(fd =>fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }
        [Test]
        public void DownloadInstaller_DownloadCompleted_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }
    }
}
using System.Net;
using PrimeService.mocking;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IFileDownloader _fileDownloader;
        public InstallerHelper(IFileDownloader downloader)
        {
            this._fileDownloader = downloader;

        }
        public bool DownloadInstaller(string customerName, string installerName)
        {
           
            try
            {
                _fileDownloader.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
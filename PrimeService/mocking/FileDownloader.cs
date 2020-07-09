using System.Net;

namespace PrimeService.mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }

    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();

            client.DownloadFile(url, path);
        }
    }
}
using PrimeService.mocking;

namespace PrimeService.UnitTests
{
    public class FakeFileReader : IFileReader
    {
        public virtual string Read(string path)
        {
            return "";
        }
    }
}
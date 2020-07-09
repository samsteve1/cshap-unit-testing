using System.Collections.Generic;
using TestNinja.Mocking;
using System.Linq;

namespace PrimeService.mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }

    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (var context = new VideoContext())
            {
                var videos = (from Video in context.Videos where !Video.IsProcessed select Video).ToList();

                return videos;
            }
        }
    }
}
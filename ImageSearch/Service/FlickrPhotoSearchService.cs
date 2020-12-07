using FlickrNet;
using WpfApp1.Service_Contract;

namespace WpfApp1.Service
{
    public class FlickrPhotoSearchService : IFlickrPhotoSearchService
    {
        public PhotoCollection SearchPhotos(string searchString)
        {
            const string apiKey = "37c9f47fd84e5905b7cb7c6e98037d92";

            Flickr flickr = new Flickr(apiKey);

            var options = new PhotoSearchOptions
            {
                Tags = searchString,
                PerPage = 20,
                Page = 1
            };

            return flickr.PhotosSearch(options);
        }

    }
}

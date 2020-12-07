using FlickrNet;

namespace WpfApp1.Service_Contract
{
    public interface IFlickrPhotoSearchService
    {
        PhotoCollection SearchPhotos(string searchString);
    }
}

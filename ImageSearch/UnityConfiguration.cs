using Unity;
using WpfApp1.Service;
using WpfApp1.Service_Contract;
using WpfApp1.View_Model;
using WpfApp1.View_Model_Contract;

public static class UnityConfiguration
{
    public static IUnityContainer CreateContainer()
    {
        var unityContainer = new UnityContainer();

        unityContainer.RegisterType<IMainWindowViewModel, MainWindowViewModel>();

        unityContainer.RegisterType<IFlickrPhotoSearchService, FlickrPhotoSearchService>();

        return unityContainer;
    }
}

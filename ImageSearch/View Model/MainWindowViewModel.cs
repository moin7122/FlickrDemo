using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Unity;
using WpfApp1.Command;
using WpfApp1.Model;
using WpfApp1.Service_Contract;
using WpfApp1.View_Model_Contract;

namespace WpfApp1.View_Model
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        #region Properties

        public IFlickrPhotoSearchService Service { get; set; }

        public List<PhotoPathModel> PhotoPathList { get; set; }

        public string SearchString { get; set; }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchCommandExecute, null);
            }
        }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            this.Service = App.Container.Resolve<IFlickrPhotoSearchService>();            
        }

        #endregion

        #region Methods        

        public void SearchCommandExecute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return;

            var photos = this.Service.SearchPhotos(SearchString);
            var listOfUrls = photos.Select(x => x.MediumUrl).ToList();
            PhotoPathList = new List<PhotoPathModel>();
            listOfUrls.ForEach(
                x =>
                {
                    PhotoPathList.Add(new PhotoPathModel
                    {
                        Path = x
                    });
                });
            RaisePropertyChanged("PhotoPathList");
        }

        #endregion
    }
}
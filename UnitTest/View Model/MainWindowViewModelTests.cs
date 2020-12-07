using FlickrNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using WpfApp1.Service_Contract;

namespace WpfApp1.View_Model.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {



        public MainWindowViewModel ViewModel { get; set; }

        public readonly Mock<IFlickrPhotoSearchService> mockService = new Mock<IFlickrPhotoSearchService>();

        public MainWindowViewModelTests()
        {
            this.ViewModel = new MainWindowViewModel();
            this.ViewModel.Service = mockService.Object;
        }
        [TestMethod()]
        public void SearchCommandExecuteTest()
        {
            // Actors
            const string searchString = "Nature";
            this.ViewModel.SearchString = searchString;
            this.mockService.Setup(x => x.SearchPhotos(searchString)).Returns(new PhotoCollection
            {
                new Photo()
            });

            // Activities            
            this.ViewModel.SearchCommand.Execute(null);

            var expectedPaths = this.ViewModel.PhotoPathList.Select(x => x.Path).ToList();

            // Asserts
            Assert.IsNotNull(this.ViewModel.PhotoPathList);
            this.mockService.Verify(x => x.SearchPhotos(searchString));
        }
    }
}
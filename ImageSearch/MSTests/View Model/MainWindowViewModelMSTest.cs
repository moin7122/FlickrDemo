using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WpfApp1.Service_Contract;
using FlickrNet;
using Xunit.Sdk;

namespace WpfApp1.View_Model.Tests
{
    [TestClass()]
    public class MainWindowViewModelMSTest
    {
        public MainWindowViewModel ViewModel { get; set; }

        public readonly Mock<IFlickrPhotoSearchService> mockService = new Mock<IFlickrPhotoSearchService>();

        public MainWindowViewModelMSTest()
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
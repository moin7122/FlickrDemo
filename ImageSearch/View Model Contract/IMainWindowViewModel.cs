using System.Collections.Generic;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.View_Model_Contract
{
    public interface IMainWindowViewModel
    {
        List<PhotoPathModel> PhotoPathList { get; set; }

        string SearchString { get; set; }

        ICommand SearchCommand { get; }
        
    }
}

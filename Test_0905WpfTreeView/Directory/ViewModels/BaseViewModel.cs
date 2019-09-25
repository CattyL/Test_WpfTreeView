using PropertyChanged;
using System.ComponentModel;

namespace Test_0905WpfTreeView
{
    /// <summary>
    /// A base view model that fires property Changed events as needed
    /// </summary>
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e)=>{};
    }
}

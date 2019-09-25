using PropertyChanged;
using System.ComponentModel;

namespace Test_0905WpfTreeView
{
    [ImplementPropertyChanged]
    public class Class1 : INotifyPropertyChanged
    {
        //private string mTest;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test { get; set; }

        
    }
}

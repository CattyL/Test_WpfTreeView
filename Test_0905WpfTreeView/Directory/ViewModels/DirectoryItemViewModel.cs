using System.Collections.ObjectModel;

namespace Test_0905WpfTreeView
{
    /// <summary>
    /// A view model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The full path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The type of this item
        /// </summary>
        public DiretoryItemType Type { get; set; }

        public string Name
        {
            get
            {
                return this.Type == DiretoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpanded { get { return this.Type != DiretoryItemType.file; } }
    }
}

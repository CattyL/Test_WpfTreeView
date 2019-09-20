using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Test_0905WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region On Loaded



        #endregion

        #region Folder Expanded

        /// <summary>
        /// When a folder is expanded, find the sub folders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial Checks
            var item = (TreeViewItem)sender;

            // If the item only contains the dummy data 
            // 当item的数量只有一个或当前结点为空
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            // Clear dummy data
            // 清理
            item.Items.Clear();

            // Get full path
            // 得到整个完整路径
            var fullPath = (string)item.Tag;

            #endregion

            #region Get Folders

            // Create a blank list for directories
            // 为目录创建一个空白列表
            var directories = new List<string>();

            // Try and get directories from the folder ignoring any issues doing so 
            // 尝试从文件夹中获取目录，忽略这样做的任何问题
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
                
            }
            catch { }

            // For each directory
            directories.ForEach(directoryPath =>
            {
                // Create directory item
                // 创建目录项
                var subItem = new TreeViewItem()
                {
                    // Set header as folder name
                    // 将头设置为文件夹名
                    Header = GetFileFolderName(directoryPath),
                    // Add tag as full path
                    // 将标记添加为完整路径
                    Tag = directoryPath
                };

                // Add dummy item so we can expand folder
                // 添加虚拟项目，以便我们可以展开文件夹
                subItem.Items.Add(null);

                // Handle expanding
                // 处理展开
                subItem.Expanded += Folder_Expanded;

                // Add this item to the parent
                // 将此项添加到父项
                item.Items.Add(subItem);
            });

            #endregion

            #region Get files

            // Create a blank list for files
            // 为目录创建一个空白列表
            var files = new List<string>();

            // Try and get files from the folder ignoring any issues doing so 
            // 尝试从文件夹中获取目录，忽略这样做的任何问题
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    files.AddRange(fs);

            }
            catch { }

            // For each file
            files.ForEach(filePath =>
            {
                // Create file item
                // 创建目录项
                var subItem = new TreeViewItem()
                {
                    // Set header as file name
                    // 将头设置为文件名
                    Header = GetFileFolderName(filePath),
                    // Add tag as full path
                    // 将标记添加为完整路径
                    Tag = filePath
                };

                // Add this item to the parent
                // 将此项添加到父项
                item.Items.Add(subItem);
            });

            #endregion
        }

        #endregion


    }
}

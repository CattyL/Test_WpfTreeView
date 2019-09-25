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

        ///// <summary>
        ///// When a folder is expanded, find the sub folders/files
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Folder_Expanded(object sender, RoutedEventArgs e)
        //{
        //    #region Initial Checks

        //    //var item = (TreeViewItem)sender;

        //    //// If the item only contains the dummy data 
        //    //// 当item的数量只有一个或当前结点为空
        //    //if (item.Items.Count != 1 || item.Items[0] != null)
        //    //    return;

        //    //// Clear dummy data
        //    //// 清理
        //    //item.Items.Clear();

        //    //// Get full path
        //    //// 得到整个完整路径
        //    //var fullPath = (string)item.Tag;

        //    #endregion

            

            
        //}

        #endregion


    }
}

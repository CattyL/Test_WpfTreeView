using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Test_0905WpfTreeView
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem
            {
                FullPath = drive,
                Type = DiretoryItemType.Drive
            }).ToList();

            ////get every logical drive on the machine
            //foreach (var drive in Directory.GetLogicalDrives())
            //{
            //    // Create a new item fot it
            //    var item = new TreeViewItem()
            //    {
            //        // Set the header
            //        Header = drive,
            //        // Set the full path
            //        Tag = drive
            //    };

            //    // Add a dummy item
            //    // 添加一个虚拟项
            //    item.Items.Add(null);

            //    // Listen out for the item being expanded
            //    // 注意正在展开的项
            //    item.Expanded += Folder_Expanded;

            //    // Add it to main tree-view 
            //    // 将其添加到主树视图
            //    FolderView.Items.Add(item);
            //}
        }

        #region Helpers

        /// <summary>
        /// Find the file or folder name from a full path 
        /// 从完整路径中找到文件或文件夹名称
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // C:\Something\a folder
            // C:\Something\a file.png
            // a file file.png

            // If we have no path,return empty
            // 如果没有路径，返回空
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slashes back slashes
            // 把所有的斜杠都变成反斜杠
            var normalizedPath = path.Replace('/', '\\');

            // Find the last backslash in the path
            // 找到路径中的最后一个反斜杠
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If we don't find a backslash, return the path itself
            if (lastIndex <= 0)
                return path;
            // Return the name after the last back slash
            return path.Substring(lastIndex + 1);
        }

        #endregion
    }
}

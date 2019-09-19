using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Test_0905WpfTreeView
{
    /// <summary>
    /// Converts a full path to a specific image type of a drive, folder or file 将完整路径转换为驱动器、文件夹或文件的特定图像类型
    /// </summary>
    [ValueConversion(typeof(string),typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the full path
            var path = (string)value;

            // If the path is full, ignore
            if (path == null)
                return null;

            // Get the name of the file/folder
            var name = MainWindow.GetFileFolderName(path);

            // By default, we presume an image
            var image = "Images/file.png";

            // If the name is blank, we presume it's a drive as we cannot have a blank file or folder name
            if (string.IsNullOrEmpty(name))
                image = "Images/drive.png";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "Images/folder-closed.png";

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using WorkspaceLauncher.Models;

namespace WorkspaceLauncher
{
    internal class RemoveItemCommandParameterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var collection = values[0] as ObservableCollection<WorkspaceItem>;
            var item = values[1] as WorkspaceItem;

            return (collection, item);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

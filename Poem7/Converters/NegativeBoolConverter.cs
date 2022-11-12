using System.Globalization;

namespace Poem7.Converters;

public class NegativeBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture) => value is bool b ? !b : (object)null;

    public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture) => throw new NotImplementedException();

}

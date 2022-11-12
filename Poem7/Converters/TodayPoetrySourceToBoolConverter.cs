using System.Globalization;

namespace Poem7.Converters;

public class TodayPoetrySourceToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        value is string source && parameter is string expectedSource && source == expectedSource;

    public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture) => throw new NotImplementedException();
}

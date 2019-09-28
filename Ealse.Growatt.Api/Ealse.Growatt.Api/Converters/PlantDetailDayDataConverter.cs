using System;
using System.Globalization;

namespace Ealse.Growatt.Api.Converters
{
    public class PlantDetailDayDataConverter : DictionaryBaseConverter<DateTime, double>
    {
        public override DateTime GetKey(string propertyName)
        {
            DateTime.TryParseExact(propertyName, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
            return result;
        }

        public override double GetValue(string propertyValue)
        {
            double.TryParse(propertyValue, NumberStyles.Number, CultureInfo.InvariantCulture, out double value);
            return value;
        }
    }
}

using System;
using System.Globalization;

namespace Ealse.Growatt.Api.Converters
{
    public class PlantDetailTotalDataConverter : DictionaryBaseConverter<DateTime, double>
    {
        public override DateTime GetKey(string propertyName)
        {
            DateTime.TryParseExact(propertyName, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
            return result;
        }

        public override double GetValue(string propertyValue)
        {
            double.TryParse(propertyValue, NumberStyles.Number, CultureInfo.InvariantCulture, out double value);
            return value;
        }
    }
}

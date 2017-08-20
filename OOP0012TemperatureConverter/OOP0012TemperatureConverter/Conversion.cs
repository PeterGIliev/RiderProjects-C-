namespace OOP0012TemperatureConverter
{
    public class Conversion
    {
        
        public double ConversionMethod(double measurement, string measurementSystem)
        {
            var convertedMeasurement = 0.0;
            if (measurementSystem == "Celsius")
            {
                convertedMeasurement = measurement * 9 / 5 + 32;
            }
            else
            {
                convertedMeasurement = (measurement - 32) * 5 / 9;
            }

            return convertedMeasurement;
        }
        
    }
}
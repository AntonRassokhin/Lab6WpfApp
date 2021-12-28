using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6WpfApp
{
    class WeatherControl: DependencyObject
    {
        private static readonly DependencyProperty TemperatureProperty;
        private string windDirection;
        private int windSpeed;
        private enum fallout
        {
            Sunny,
            Clowdy,
            Rain,
            Snow
        }

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static object CoerceTemperature (DependencyObject d, object value)
        {
            int v = (int)value;
            if (v >= -50 && v<= 50)
                return v;
            else
                return 0;
        }

        private static bool ValidateTemperature (object validValue)
        {
            int v = (int)validValue;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

    }
}

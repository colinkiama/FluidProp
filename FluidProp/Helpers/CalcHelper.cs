using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace FluidProp.Helpers
{
    internal class CalcHelper
    {
        const double defaultMinWidth = 500;
        
        
        internal static double CalculateNewValue(double maxValue, double minValue, double maxWidth, double minWidth = defaultMinWidth )
        {
            double currentWidth = Window.Current.Bounds.Width;
            return (minValue + maxValue) * (currentWidth - minWidth) / (maxWidth - minWidth);
        }

        //public double RangeValueFromPercent(double percent, double min, double max)
        //{
        //    return (max - min) * percent + min;
        //}

        //public double RangePercentFromValue(double value, double min, double max)
        //{
        //    return (value - min) / (max - min);
        //}
    }
}

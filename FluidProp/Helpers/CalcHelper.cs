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
            return (maxValue - minValue) * (currentWidth - minWidth) / (maxWidth - minWidth) + minValue;
        }
    }
}

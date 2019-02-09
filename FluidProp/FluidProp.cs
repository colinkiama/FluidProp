using FluidProp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FluidProp
{
    public sealed class FluidProp: DependencyObject
    {

        static double maxWidth;

        public FluidProp()
        {
            Window.Current.SizeChanged += Current_SizeChanged;
            var currentDisplay = DisplayInformation.GetForCurrentView();
            maxWidth = currentDisplay.ScreenWidthInRawPixels;
            currentDisplay.OrientationChanged += CurrentDisplay_OrientationChanged;
            UpdateAttatchedObjects();
        }

        private void CurrentDisplay_OrientationChanged(DisplayInformation sender, object args)
        {
            maxWidth = sender.ScreenWidthInRawPixels;
            UpdateAttatchedObjects();
              
            
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (e.Size.Width > 0)
            {
                UpdateAttatchedObjects();
            }
        }

        private void UpdateAttatchedObjects()
        {
            foreach (var item in attatchedObjects)
            {
                if (item is Control)
                {
                    item.SetValue(Control.FontSizeProperty, UpdateValueForDependencyObject(item));
                }
                else if (item is TextBlock)
                {
                    item.SetValue(TextBlock.FontSizeProperty, UpdateValueForDependencyObject(item));
                }
            }
        }

        private double UpdateValueForDependencyObject(DependencyObject item)
        {
            double minValue = (double)item.GetValue(MinFontSizeProperty);
            double maxValue = (double)item.GetValue(MaxFontSizeProperty);
            return CalcHelper.CalculateNewValue(maxValue, minValue, maxWidth);
        }

        static List<DependencyObject> attatchedObjects = new List<DependencyObject>();

        public static DependencyProperty MinFontSizeProperty { get; } = 
            DependencyProperty.RegisterAttached("MinFontSize", typeof(double), typeof(FluidProp), null);

        public static double GetMinFontSize(DependencyObject obj)
        {
            return (double)obj.GetValue(MinFontSizeProperty);
        }

        public static void SetMinFontSize(DependencyObject obj, double value)
        {
            if (!attatchedObjects.Contains(obj))
            {
                attatchedObjects.Add(obj);
            }
            obj.SetValue(MinFontSizeProperty, value);
        }


        public static double GetMaxFontSize(DependencyObject obj)
        {
            return (double)obj.GetValue(MaxFontSizeProperty);
        }

        public static void SetMaxFontSize(DependencyObject obj, double value)
        {
            obj.SetValue(MaxFontSizeProperty, value);
        }


        // Using a DependencyProperty as the backing store for MaxFontSizeProperty.  This enables animation, styling, binding, etc...
        public static DependencyProperty MaxFontSizeProperty { get; } =
            DependencyProperty.RegisterAttached("MaxFontSize", typeof(double), typeof(FluidProp), null);


        
        




    }
}

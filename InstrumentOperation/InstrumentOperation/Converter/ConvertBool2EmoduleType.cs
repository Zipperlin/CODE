using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using InstrumentOperation.Common;

namespace InstrumentOperation.Converter
{
    class ConvertBool2EmoduleType : IValueConverter
    {
        public E_Module SetValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return false;

                var getData = (E_Module)value;
                return getData;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                switch (parameter.ToString())
                {
                    case "FF":
                        SetValue = SetValue | E_Module.e_FF_Module;
                        break;
                    case "HART":
                        SetValue = SetValue | E_Module.e_HART_Module;
                        break;
                    case "PA":
                        SetValue = SetValue | E_Module.e_PA_Module;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                
            }
            return SetValue;
        }
    }
}

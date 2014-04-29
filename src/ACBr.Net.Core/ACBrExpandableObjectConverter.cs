using System;
using System.Globalization;
using System.ComponentModel;

namespace ACBr.Net.Core
{
    public class ACBrExpandableObjectConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,  CultureInfo culture,  object value, Type destType)
        {
            if ((value != null) && (destType == typeof(string)))
            {
                return (String.Format("({0})", value.GetType().Name));
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}

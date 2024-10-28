using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Services
{

    public class MultilineStringEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.None;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var propDesc = context.PropertyDescriptor;
            if (propDesc != null)
            {
                propDesc.SetValue(context.Instance, value);
                propDesc.SetValue("Multiline", true);
            }
            return value;
        }
    }

    public class ToFormatConverterDebtToEquity : TypeConverter
    {
        


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            float amount = (float)value; // Replace with your own amount
            string formattedValue = string.Format("{0:#,##0.0}", amount);


            return base.ConvertTo(context, culture, formattedValue + "%", destinationType);
        }
    }


    


    public class ToFormatConverterRatio : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            float amount = (float)value; // Replace with your own amount
            string formattedValue = string.Format("{0:#,##0.0}", amount);


            return base.ConvertTo(context, culture, formattedValue, destinationType);
        }
    }

    public class ToFormatConverterIndustry : TypeConverter
    {



        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is string)
            {
                string input = (string)value;
                return $"{input.Substring(0,20)}{Environment.NewLine}{input.Substring(20)}";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }


    public class ToFormatConverterMarketCap : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {

            decimal amount = (decimal)value; // Replace with your own amount
            string formattedAmount = string.Format("{0:#,##,##,###}", amount);
            string formattedAmountWithCurrency = string.Format("₹ {0:#,##,##,###}", amount);

            return base.ConvertTo(context, culture, formattedAmountWithCurrency, destinationType);
        }

    }


    public class ToFormatConverterCurrency : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {

            decimal amount = (decimal)value; // Replace with your own amount
            string formattedAmount = string.Format("{0:#,##,##,###.00}", amount);
            string formattedAmountWithCurrency = string.Format("₹ {0:#,##,##,###.00}", amount);

            return base.ConvertTo(context, culture, formattedAmountWithCurrency, destinationType);
        }

    }


    public class ToFormatConverterCurrencyFloat : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {

            float amount = (float)value; // Replace with your own amount
            string formattedAmount = string.Format("{0:#,##,##,###.00}", amount);
            string formattedAmountWithCurrency = string.Format("₹ {0:#,##,##,###.00}", amount);

            return base.ConvertTo(context, culture, formattedAmountWithCurrency, destinationType);
        }

    }
    public class ToUpperCaseConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is string)
            {
                return ((string)value).ToUpperInvariant();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class UpperCaseAttribute : Attribute
    {
        public bool ConvertToUpper { get; set; }

        public UpperCaseAttribute(bool convertToUpper)
        {
            ConvertToUpper = convertToUpper;
        }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public class NumericRangeAttribute : Attribute
    {
        private readonly double _minValue;
        private readonly double _maxValue;

        public NumericRangeAttribute(double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public double MinValue
        {
            get { return _minValue; }
        }

        public double MaxValue
        {
            get { return _maxValue; }
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FloatFormatAttribute : Attribute
    {
        public string Format { get; }

        public FloatFormatAttribute(string format)
        {
            Format = format;
        }
    }


    public class MyPropertyConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return value.ToString();
        }
    }
    public class StockDetails
    {

        


        [Category("Summary")]
        private string industry;


        [Category("Summary")]
        private string stockName;


        [Category("Summary")]
        private string series;


        [Category("Summary")]
        private string isinCode;



        [Category("Summary")]
        private decimal currentPrice;


        [Category("Balance Sheet")]
        private float debtToEquity;


        [Category("Valuation Measures")]
        private float trailingPe;


        [Category("Earnings")]
        private float epsTrailing12Months;


        [Category("Earnings")]
        private float epsForward;


        [Category("Earnings")]
        private float epsCurrentYear;


        [Category("Balance Sheet")]
        private float bookValue;


        [Category("Stock Price History")]
        private float fiftyDayAverage;


        [Category("Stock Price History")]
        private float twoHundredDayAverage;


        [Category("Valuation Measures")]
        private decimal marketCap;


        [Category("Valuation Measures")]
        private float forwardPe;


        [Category("Valuation Measures")]
        private float priceToBook;


        [Category("Stock Price History")]
        private float fiftyTwoWeekLow;


        [Category("Stock Price History")]
        private float fiftyTwoWeekHigh;









        [Category("Summary")]
        [ReadOnly(true)]
        public string Industry
        {
            get { return industry; }
            set { industry = value; }
        }





        [Category("Summary")]
        [DisplayName("Stock Name")]
        [ReadOnly(true)]
        
        public string StockName
        {
            get { return stockName; }
            set { stockName = value; }
        }




        [Category("Summary")]
        [ReadOnly(true)]

        public string Series { get { return series; } set { series = value; } }




        [Category("Summary")]
        [DisplayName("ISIN Code")]
        [ReadOnly(true)]
        public string IsinCode { get { return isinCode; } set { isinCode = value; } }




        [Category("Summary")]
        [DisplayName("Current Price")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterCurrency))]
        public decimal CurrentPrice { get { return currentPrice; } set { currentPrice = value; } }




        [Category("Balance Sheet")]
        [DisplayName("Debt To Equity Ratio")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterDebtToEquity))]
        public float DebtToEquity { get { return debtToEquity; } set { debtToEquity = value; } }





        [Category("Valuation Measures")]
        [DisplayName("Trailing PE")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterRatio))]
        public float TrailingPe { get { return trailingPe; } set { trailingPe = value; } }




        [Category("Earnings")]
        [DisplayName("EPS Trailing 12 Months")]
        [TypeConverter(typeof(ToFormatConverterRatio))]
        [ReadOnly(true)]
        public float EpsTrailing12Months { get { return epsTrailing12Months; } set { epsTrailing12Months = value; } }




        [Category("Earnings")]
        [DisplayName("EPS Forward")]
        [TypeConverter(typeof(ToFormatConverterRatio))]
        [ReadOnly(true)]
        public float EpsForward { get { return epsForward; } set { epsForward = value; } }



        [Category("Earnings")]
        [DisplayName("EPS Current Year")]
        [TypeConverter(typeof(ToFormatConverterRatio))]
        [ReadOnly(true)]
        public float EpsCurrentYear { get { return epsCurrentYear; } set { epsCurrentYear = value; } }



        [Category("Balance Sheet")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterCurrencyFloat))]
        public float BookValue { get { return bookValue; } set { bookValue = value; } }



        [Category("Stock Price History")]
        [DisplayName("Fifty Day Moving Average")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterCurrencyFloat))]
        public float FiftyDayAverage { get { return fiftyDayAverage; } set { fiftyDayAverage = value; } }


        [Category("Stock Price History")]
        [DisplayName("Two Hundred Day Moving Average")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterCurrencyFloat))]
        public float TwoHundredDayAverage { get { return twoHundredDayAverage; } set { twoHundredDayAverage = value; } }





        [Category("Valuation Measures")]
        [DisplayName("Market Cap")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterMarketCap))]
        public decimal MarketCap { get { return marketCap; } set { marketCap = value; } }




        [Category("Valuation Measures")]
        [DisplayName("Forward PE")]
        [TypeConverter(typeof(ToFormatConverterRatio))]
        [ReadOnly(true)]
        public float ForwardPe { get { return forwardPe; } set { forwardPe = value; } }



        [Category("Valuation Measures")]
        [DisplayName("Price to Book Ratio")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterRatio))]
        public float PriceToBook { get { return priceToBook; } set { priceToBook = value; } }




        [Category("Stock Price History")]
        [DisplayName("Fifty Two Week Low")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterCurrencyFloat))]
        public float FiftyTwoWeekLow { get { return fiftyTwoWeekLow; } set { fiftyTwoWeekLow = value; } }



        [Category("Stock Price History")]
        [DisplayName("Fifty Two Week High")]
        [ReadOnly(true)]
        [TypeConverter(typeof(ToFormatConverterCurrencyFloat))]
        public float FiftyTwoWeekHigh { get { return fiftyTwoWeekHigh; } set { fiftyTwoWeekHigh = value; } }




    }

    
}

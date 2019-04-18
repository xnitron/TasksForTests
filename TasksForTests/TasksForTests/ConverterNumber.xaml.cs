using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TasksForTests
{
    public partial class ConverterNumber : ContentPage
    {
        public ConverterNumber()
        {
            InitializeComponent();
        }

        private void EntryDecChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
            {
                long number = long.Parse(e.NewTextValue);

                SystemsNumberToSring(number);
            }
            else
            {
                EmptyStringSystemsNumber();
            }
        }

        private void EntryHexChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
            {
                long number = long.Parse(e.NewTextValue, NumberStyles.HexNumber);
                SystemsNumberToSring(number);
            }
            else
            {
                EmptyStringSystemsNumber();
            }
        }

        private void EntryBinChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
            {
                long number = Convert.ToInt32(e.NewTextValue, 2);
                SystemsNumberToSring(number);
            }
            else
            {
                EmptyStringSystemsNumber();
            }
        }

        private void EntryOctChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue) && e.NewTextValue != e.OldTextValue)
            {
                long number = Convert.ToInt32(e.NewTextValue, 8);
                SystemsNumberToSring(number);
            }
            else
            {
                EmptyStringSystemsNumber();
            }
        }


        private void SystemsNumberToSring(long number)
        {
            EntryDec.Text = Convert.ToString(number, 10);
            EntryHex.Text = Convert.ToString(number, 16);
            EntryOct.Text = Convert.ToString(number, 8);
            EntryBin.Text = Convert.ToString(number, 2);
        }

        private void EmptyStringSystemsNumber()
        {
            EntryDec.Text = string.Empty;
            EntryHex.Text = string.Empty;
            EntryOct.Text = string.Empty;
            EntryBin.Text = string.Empty;
        }
    }
}

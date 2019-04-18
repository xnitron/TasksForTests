using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksForTests
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Alias : ContentPage, INotifyPropertyChanged
    {
        private string[] words = { "футбол", "каша", "карандаш", "тигр", "автобус", "прекрасный", "роза", "учитель" };
        private int counter = 0;
        private int points = 0;
        private bool isVisible = false;

        public Alias()
        {
            InitializeComponent();

            BindingContext = this;
          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool VisibleBtn
        {
            get
            {
                return isVisible;
            }    
            set
            {
                if (value != isVisible)
                {
                    isVisible = value;

                    NotifyPropertyChanged();
                }
            }
        }

        private void NewGame(object sender, EventArgs e)
        {
            points = 0;
            int sec = 10;
            VisibleBtn = true;
            WordForGuess.Text = words[0];
            Points.Text = points.ToString();
            
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
               {
                   if (sec > 0)
                   {
                       sec--;
                       Timer.Text = sec.ToString();

                       return true;
                   }

                   VisibleBtn = false;

                   return false;
               });
        }

        private void GuessedWord(object sender, EventArgs e)
        {
            WordForGuess.Text = NextWord();
            points++;
            Points.Text = points.ToString();
        }

        private void SkippedWord(object sender, EventArgs e)
        {
            WordForGuess.Text = NextWord();
            points--;
            Points.Text = points.ToString();
        }

        private string NextWord()
        {
            if (counter == words.Length - 1)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }

            return words[counter];
        }
    }
}
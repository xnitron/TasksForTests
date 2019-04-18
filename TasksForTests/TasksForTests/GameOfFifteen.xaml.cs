using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksForTests
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameOfFifteen : ContentPage
    {

        Game game;
        public GameOfFifteen()
        {
            InitializeComponent();

            game = new Game(4);
            Refresh();
        }

        private void NewGame(object sender, EventArgs e)
        {
            game.Start();

            for (int i = 0; i < 3; i++)
            {
                game.RandomShift();
            }

            Refresh();
        }

        private void Refresh()
        {
            for (int position = 0; position < 16; position++)
            {
                BtnPosition(position).Text = game.GetNumber(position).ToString();
                BtnPosition(position).IsVisible = game.GetNumber(position) > 0;
            }
        }

        private Button BtnPosition(int position)
        {
            switch(position)
            {
                case 0: return Btn0;
                case 1: return Btn1;
                case 2: return Btn2;
                case 3: return Btn3;
                case 4: return Btn4;
                case 5: return Btn5;
                case 6: return Btn6;
                case 7: return Btn7;
                case 8: return Btn8;
                case 9: return Btn9;
                case 10: return Btn10;
                case 11: return Btn11;
                case 12: return Btn12;
                case 13: return Btn13;
                case 14: return Btn14;
                case 15: return Btn15;
                default: return null;
            }
        }

        private void Btn0_Clicked(object sender, EventArgs e)
        {
            int position = Convert.ToInt16(((Button)sender).CommandParameter);
            game.Shift(position);
            Refresh();

            if(game.CheckNumbers())
            {
                DisplayAlert("Win", "You Win!", "Ok");
            }
        }
    }
}
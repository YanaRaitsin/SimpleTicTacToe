using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToeWithAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TicTacToeGameplayWindow : Window
    {
        public bool Turn { get; set; }
        public int TurnCount { get; set; }
        public static string FirstPlayer { get; set; }
        public static string SecondPlayer { get; set; }
        public static bool IsAgaintComputer { get; set; }
        public bool IsWinner { get; set; }
        public TicTacToeGameplayWindow()
        {
            InitializeComponent();
            FirstPlayerLabel.Content = FirstPlayer + " Win Count:";
            SecondPlayerLabel.Content = SecondPlayer + " Win Count:";
            InitEventButtons();
            InitTurnVars();
            CheckPlayAgainstComputer();
            DisableResetCountersButton();
        }

        private void DisableResetCountersButton()
        {
            if (OWinCount.Content.Equals("0") && XWinCount.Content.Equals("0") && DrawCount.Content.Equals("0"))
            {
                ResetCountersButton.IsEnabled = false;
            }
        }

        private void InitTurnVars()
        {
            Turn = true;
            TurnCount = 0;
        }

        private void InitEventButtons()
        {
            Button1.Click += ButtonClicked;
            Button2.Click += ButtonClicked;
            Button3.Click += ButtonClicked;
            Button4.Click += ButtonClicked;
            Button5.Click += ButtonClicked;
            Button6.Click += ButtonClicked;
            Button7.Click += ButtonClicked;
            Button8.Click += ButtonClicked;
            Button9.Click += ButtonClicked;
        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            if (Turn)
            {
                clicked.Content = "X";
            }
            else
            {
                clicked.Content = "O";
            }
            clicked.IsEnabled = false;
            Turn = !Turn;
            TurnCount++;
            CheckForWinner();
            if(!Turn && IsAgaintComputer && !IsWinner && TurnCount!=9)
            {
                ComputerMakeMove();
            }
        }

        private void ComputerMakeMove()
        {
            Button move = null;
            move = LookForWinOrBlock("O");
            if(move == null)
            {
                move = LookForWinOrBlock("X");
                if(move == null)
                {
                    move = LookForCorner();
                    if(move == null)
                    {
                        move = LookForOpenSpace();
                    }
                }
            }
            move.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private Button LookForOpenSpace()
        {
            foreach (var current in TicTacToeGrid.Children.OfType<Button>())
            {
                if (current != null)
                {
                    if (current.Content.Equals(""))
                        return current;
                }
            }
            return null;
        }

        private Button LookForCorner()
        {
            if (Button1.Content.Equals("O"))
            {
                if (Button3.Content.Equals(""))
                {
                    return Button3;
                }
                if (Button9.Content.Equals(""))
                {
                    return Button9;
                }
                if (Button7.Content.Equals(""))
                {
                    return Button7;
                }
            }

            if (Button3.Content.Equals("O"))
            {
                if (Button1.Content.Equals(""))
                {
                    return Button1;
                }
                if (Button9.Content.Equals(""))
                {
                    return Button9;
                }
                if (Button7.Content.Equals(""))
                {
                    return Button7;
                }
            }

            if (Button9.Content.Equals("O"))
            {
                if (Button1.Content.Equals(""))
                {
                    return Button1;
                }
                if (Button3.Content.Equals(""))
                {
                    return Button3;
                }
                if (Button7.Content.Equals(""))
                {
                    return Button7;
                }
            }

            if (Button7.Content.Equals("O"))
            {
                if (Button1.Content.Equals(""))
                {
                    return Button1;
                }
                if (Button3.Content.Equals(""))
                {
                    return Button3;
                }
                if (Button9.Content.Equals(""))
                {
                    return Button9;
                }
            }

            return Button1.Content.Equals("")
                ? Button1
                : Button3.Content.Equals("") ? Button3 : Button7.Content.Equals("") ? Button7 : Button9.Content.Equals("") ? Button9 : null;
        }

        private Button LookForWinOrBlock(string mark)
        {
            if (Button1.Content.Equals(mark) && Button2.Content.Equals(mark) && Button3.Content.Equals(""))
            {
                return Button3;
            }
            if (Button2.Content.Equals(mark) && Button3.Content.Equals(mark) && Button1.Content.Equals(""))
            {
                return Button1;
            }
            if (Button1.Content.Equals(mark) && Button3.Content.Equals(mark) && Button1.Content.Equals(""))
            {
                return Button2;
            }

            if (Button4.Content.Equals(mark) && Button5.Content.Equals(mark) && Button6.Content.Equals(""))
            {
                return Button6;
            }
            if (Button5.Content.Equals(mark) && Button6.Content.Equals(mark) && Button4.Content.Equals(""))
            {
                return Button4;
            }
            if (Button4.Content.Equals(mark) && Button6.Content.Equals(mark) && Button5.Content.Equals(""))
            {
                return Button5;
            }

            if (Button7.Content.Equals(mark) && Button8.Content.Equals(mark) && Button9.Content.Equals(""))
            {
                return Button9;
            }
            if (Button7.Content.Equals("") && Button8.Content.Equals(mark) && Button9.Content.Equals(mark))
            {
                return Button7;
            }
            if (Button7.Content.Equals(mark) && Button8.Content.Equals("") && Button9.Content.Equals(mark))
            {
                return Button8;
            }

            //VERTICAL TESTS
            if (Button1.Content.Equals(mark) && Button4.Content.Equals(mark) && Button7.Content.Equals(""))
            {
                return Button7;
            }
            if (Button4.Content.Equals(mark) && Button7.Content.Equals(mark) && Button1.Content.Equals(""))
            {
                return Button1;
            }
            if (Button1.Content.Equals(mark) && Button7.Content.Equals(mark) && Button4.Content.Equals(""))
            {
                return Button4;
            }

            if (Button2.Content.Equals(mark) && Button5.Content.Equals(mark) && Button8.Content.Equals(""))
            {
                return Button8;
            }
            if (Button5.Content.Equals(mark) && Button8.Content.Equals(mark) && Button2.Content.Equals(""))
            {
                return Button2;
            }
            if (Button2.Content.Equals(mark) && Button8.Content.Equals(mark) && Button5.Content.Equals(""))
            {
                return Button5;
            }

            if (Button3.Content.Equals(mark) && Button6.Content.Equals(mark) && Button9.Content.Equals(""))
            {
                return Button9;
            }
            if (Button6.Content.Equals(mark) && Button9.Content.Equals(mark) && Button3.Content.Equals(""))
            {
                return Button3;
            }
            if (Button3.Content.Equals(mark) && Button9.Content.Equals(mark) && Button6.Content.Equals(""))
            {
                return Button6;
            }

            //DIAGONAL TESTS
            if (Button1.Content.Equals(mark) && Button5.Content.Equals(mark) && Button9.Content.Equals(""))
            {
                return Button9;
            }
            if (Button5.Content.Equals(mark) && Button9.Content.Equals(mark) && Button1.Content.Equals(""))
            {
                return Button1;
            }
            if (Button1.Content.Equals(mark) && Button9.Content.Equals(mark) && Button5.Content.Equals(""))
            {
                return Button5;
            }

            if (Button3.Content.Equals(mark) && Button5.Content.Equals(mark) && Button7.Content.Equals(""))
            {
                return Button7;
            }
            if (Button5.Content.Equals(mark) && Button7.Content.Equals(mark) && Button3.Content.Equals(""))
            {
                return Button3;
            }
            if (Button3.Content.Equals(mark) && Button7.Content.Equals(mark) && Button5.Content.Equals(""))
            {
                return Button5;
            }

            return null;
        }

        private void CheckForWinner()
        {
            IsWinner = false;
            //vertical
            if ((Button1.Content == Button4.Content) && (Button4.Content == Button7.Content) && !Button1.IsEnabled)
            {
                IsWinner = true;
            }
            else if ((Button2.Content == Button5.Content) && (Button5.Content == Button8.Content) && !Button2.IsEnabled)
            {
                IsWinner = true;
            }
            else if ((Button3.Content == Button6.Content) && (Button6.Content == Button9.Content) && !Button3.IsEnabled)
            {
                IsWinner = true;
            }
            //horizontal
            if ((Button1.Content == Button2.Content) && (Button2.Content == Button3.Content) && !Button1.IsEnabled)
            {
                IsWinner = true;
            }
            else if ((Button4.Content == Button5.Content) && (Button5.Content == Button6.Content) && !Button4.IsEnabled)
            {
                IsWinner = true;
            }
            else if ((Button7.Content == Button8.Content) && (Button8.Content == Button9.Content) && !Button7.IsEnabled)
            {
                IsWinner = true;
            }
            //diagonal
            if ((Button1.Content == Button5.Content) && (Button5.Content == Button9.Content) && !Button1.IsEnabled)
            {
                IsWinner = true;
            }
            else if ((Button3.Content == Button5.Content) && (Button5.Content == Button7.Content) && !Button7.IsEnabled)
            {
                IsWinner = true;
            }
            if (IsWinner)
            {
                DisableButtons();
                string winner = "";
                if (Turn)
                {
                    winner = "O";
                    OWinCount.Content = int.Parse(OWinCount.Content.ToString()) + 1;
                    ResetCountersButton.IsEnabled = true;
                }
                else
                {
                    winner = "X";
                    XWinCount.Content = int.Parse(XWinCount.Content.ToString()) + 1;
                    ResetCountersButton.IsEnabled = true;
                }
                MessageBox.Show(winner + " Won!", "Tic Tac Toe");
            }
            else
            {
                if(TurnCount == 9)
                {
                    DrawCount.Content = int.Parse(DrawCount.Content.ToString()) + 1;
                    ResetCountersButton.IsEnabled = true;
                    MessageBox.Show("There is a draw!","Tic Tac Toe");
                }
            }
        }
        private void DisableButtons()
        {
            foreach(var current in TicTacToeGrid.Children.OfType<Button>())
            {
                current.IsEnabled = false;
            }
        }

        private void ResetGame(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            InitTurnVars();
            foreach (var current in TicTacToeGrid.Children.OfType<Button>())
            {
                current.IsEnabled = true;
                current.Content = "";
            }
        }

        private void ButtonEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button.IsEnabled)
            {
                button.Content = Turn ? "X" : "O";
            }
        }

        private void ButtonLeave(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if(button.IsEnabled)
            {
                button.Content = "";
            }
        }

        private void ResetCounters(object sender, RoutedEventArgs e)
        {
            OWinCount.Content = "0";
            XWinCount.Content = "0";
            DrawCount.Content = "0";
        }

        private void CheckPlayAgainstComputer()
        {
            if (IsAgaintComputer)
            {
                FirstPlayerLabel.Content = "My Win Count:";
                SecondPlayerLabel.Content = "Computer Win Count:";
            }
        }
    }
}

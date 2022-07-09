using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TicTacToeWithAI
{
    /// <summary>
    /// Interaction logic for TicTacToeNamesWindow.xaml
    /// </summary>
    public partial class TicTacToeMainWindow : Window
    {
        public TicTacToeMainWindow()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if(FirstPlayer.Text.Equals("") || SecondPlayer.Text.Equals(""))
            {
                MessageBox.Show("Please fill first player name or second player name!", "Tic Tac Toe");
                return;
            }
            Hide();
            TicTacToeGameplayWindow.FirstPlayer = FirstPlayer.Text;
            TicTacToeGameplayWindow.SecondPlayer = SecondPlayer.Text;
            var ticTacToeGameplay = new TicTacToeGameplayWindow();
            ticTacToeGameplay.ShowDialog();
            Show();
        }

        private void PlayAgainstComputer_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            TicTacToeGameplayWindow.IsAgaintComputer = true;
            var ticTacToeGameplay = new TicTacToeGameplayWindow();
            ticTacToeGameplay.ShowDialog();
            Show();
        }
    }
}

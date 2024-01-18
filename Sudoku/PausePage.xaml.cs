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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
    public partial class PausePage : Page
    {
        private GamePage _game;
        public PausePage(GamePage game)
        {
            InitializeComponent();
            _game = game;
            timeTextBlock.Text = $"Время: {_game.Minutes}:{_game.Seconds:d2}";
        }

        private void countinueButton_Click(object sender, RoutedEventArgs e)
        {
            _game.timer.Start();
            NavigationService.GoBack();
        }

        private void goToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }
    }


}

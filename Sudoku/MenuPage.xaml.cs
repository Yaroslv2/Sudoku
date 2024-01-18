using Sudoku.Models;
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
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChooseLevelPage());

        }

        private void ScoreButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ScorePage());
        }

        private void RulesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RulesPage());
        }
    }
}

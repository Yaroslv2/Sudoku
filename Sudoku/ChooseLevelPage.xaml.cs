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
    public partial class ChooseLevelPage : Page
    {
        public ChooseLevelPage()
        {
            InitializeComponent();
        }

        private void easyLevelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamePage(1));
        }

        private void mediumLevelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamePage(50));
        }

        private void hardLevelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamePage(60));
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }
    }
}

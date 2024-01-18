using Sudoku.Models;
using Sudoku.Utilites;
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
    public partial class WinPage : Page
    {
        private FileService _fileService = new FileService();
        private int _seconds;
        private int _minutes;
        public WinPage(int seconds, int minutes)
        {
            InitializeComponent();
            _seconds = seconds;
            _minutes = minutes;
            timeBlock.Text = $"Вы решили судоку за {minutes}:{seconds:d2}";
        }

        private void goToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(usernameTextBox.Text))
            {
                User user = new User(usernameTextBox.Text, $"{_minutes}:{_seconds:d2}");
                _fileService.SaveData(user);
            }
            NavigationService.Navigate(new MenuPage());
        }
    }
}

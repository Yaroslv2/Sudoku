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
    /// <summary>
    /// Логика взаимодействия для ScorePage.xaml
    /// </summary>
    public partial class ScorePage : Page
    {
        private FileService fileService = new FileService();
        public List<User> Users;
        public ScorePage()
        {
            Users = fileService.LoadData();
            InitializeComponent();
            usersListView.ItemsSource = Users;
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

using Sudoku.Models;
using Sudoku.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;

namespace Sudoku
{
    public partial class GamePage : Page
    {
        private List<Square> squares = new List<Square>();
        private Map map = new Map();
        public DispatcherTimer timer;
        public int Seconds {  get; set; }
        public int Minutes {  get; set; }
        private int _errorsCount = 0;
        private bool _noteMode;
        public bool IsNoteMode 
        {
            get => _noteMode;
            set
            {
                _noteMode = value;
                if (_noteMode)
                    switchNoteButton.Content = "Чистовик";
                else
                    switchNoteButton.Content = "Заметки";
            }
        }
        private int _hideCellsCount;
        public int HideCellsCount 
        { 
            get => _hideCellsCount; 
            set { 
                _hideCellsCount = value;
                if (_hideCellsCount == 0)
                {
                    FinishGame();
                }
            }
        }

        public int ErrorsCount
        {
            get => _errorsCount; 
            set 
            { 
                _errorsCount = value;
                errorsCounter.Text = $"Ошибки: {_errorsCount}/3";
                if (_errorsCount == 3)
                    NavigationService.Navigate(new LosePage());
            }
        }

        public GamePage(int hideCellsCount)
        {
            Seconds = 0;
            Minutes = 0;
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            errorsCounter.Text = "Ошибки: 0/3";
            timerBlock.Text = "0:00";
            map.GenerateNewMap();
            _hideCellsCount = hideCellsCount;
            GenerateMapUI();
            IsNoteMode = false;
        }

        private void FinishGame()
        {
            timer.Stop();
            NavigationService.Navigate(new WinPage(Seconds, Minutes));
        }

        private void Timer_Tick(object sender, EventArgs args)
        {
            Seconds++;
            if (Seconds >= 60)
            {
                Minutes++;
                Seconds = 0;
            }
            timerBlock.Text = $"{Minutes}:{Seconds:d2}";
        }

        private void GenerateMapUI()
        {
            int[,] hiddenMap = map.HideCells(_hideCellsCount);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Square square = new Square(this, map.GetElementByIdx(i, j), hiddenMap[i, j] == 0 ? true : false);
                    Grid.SetColumn(square, i);
                    Grid.SetRow(square, j);
                    squares.Add(square);
                    sudokuGrid.Children.Add(square);
                }
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new MenuPage());
        }

        private void switchNoteButton_Click(object sender, RoutedEventArgs e)
        {
            IsNoteMode = !IsNoteMode;
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new PausePage(this));
        }
    }
}

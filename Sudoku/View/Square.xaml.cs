using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Sudoku.View
{
    public partial class Square : UserControl
    {
        private TextBlock[,] _nodes;
        private GamePage _game;
        private int _correctValue;
        private bool _isHide;
        public bool IsHide
        {
            get => _isHide;
            set
            {
                _isHide = value;
                
                if (_isHide) { 
                    HideCell();
                }
                else
                {
                    OpenCell();
                }
            }
        }
        public Square(GamePage gamePage, int correctValue, bool hide)
        {
            _game = gamePage;
            _correctValue = correctValue;
            InitializeComponent();
            textBox.MaxLength = 1;
            _nodes = new TextBlock[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _nodes[i, j] = new TextBlock();
                    _nodes[i, j].Text = "";
                    _nodes[i, j].Foreground = Brushes.Silver;
                    _nodes[i, j].Background = Brushes.Transparent;
                    _nodes[i, j].VerticalAlignment = VerticalAlignment.Center;
                    _nodes[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetColumn(_nodes[i, j], j);
                    Grid.SetRow(_nodes[i, j], i);
                    Panel.SetZIndex(_nodes[i, j], -1);
                    nodeGrid.Children.Add(_nodes[i, j]);
                }
            }
            _isHide = hide;
            if (_isHide) HideCell();
            else OpenCell();
            textBox.TextChanged += textBox_TextChanged;
        }

        private void HideCell()
        {
            textBox.Text = string.Empty;
        }

        private void OpenCell()
        {
            textBox.Text = $"{_correctValue}";
            textBox.IsReadOnly = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _nodes[i, j].Text = "";
                }
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tsender = sender as TextBox;
            int curr;
            if (_game.IsNoteMode)
            {
                if (!int.TryParse(tsender.Text, out curr))
                {
                    tsender.Text = "";
                    return;
                }
                else if (curr != 0)
                {
                    int i, j;
                    if (curr % 3 == 0)
                    {
                        i = curr / 3 - 1;
                        j = 2;
                    }
                    else
                    {
                        i = curr / 3;
                        j = curr % 3 - 1;
                    }
                    if (string.IsNullOrEmpty(_nodes[i, j].Text))
                        _nodes[i, j].Text = curr.ToString();
                    else
                        _nodes[i, j].Text = string.Empty;

                }
                tsender.Text = "";
                return;
            }
            if (tsender.Text == string.Empty || tsender.Text == "")
            {
                tsender.Background = Brushes.Transparent;
            }
            if (!int.TryParse((sender as TextBox).Text, out curr))
            {
                (sender as TextBox).Text = "";
                return;
            }

            if (tsender.Text != _correctValue.ToString())
            {
                _game.ErrorsCount++;
                textBox.Background = Brushes.Red;
            }
            else
            {
                IsHide = false;
                _game.HideCellsCount--;
            }
        }
        
    }
}

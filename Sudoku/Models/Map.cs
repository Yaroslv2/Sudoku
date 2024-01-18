using Sudoku.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Map
    {
        private const int n = 3;
        private int[,] _map = new int[n*n, n*n];

        public Map()
        {
            ClearMap();
        }

        public int GetElementByIdx(int i, int j)
        {
            return _map[i, j];
        }

        public void ClearMap()
        {
            for (int i = 0; i < n*n; i++)
            {
                for (int j = 0; j < n*n; j++)
                {
                    _map[i,j] = 0;
                }
            }
        }

        public void GenerateNewMap()
        {
            for (int i = 0; i < n*n; i++)
            {
                for (int j = 0; j < n*n; j++)
                {
                    _map[i, j] = (i * n + i / n + j) % (n * n) + 1;
                }
            }

            for (int i = 0; i < 40; i++)
            {
                ShuffleMap(RandomProvider.RandomNext(0, 4));
            }
        }

        public void ShuffleMap(int i)
        {
            switch (i)
            {
                case 0:
                    MatrixTransposition();
                    break;
                case 1:
                    SwapRowsInBlock();
                    break;
                case 2:
                    SwapColumnsInBlock();
                    break;
                case 3:
                    SwapBlocksInRow();
                    break;
                case 4:
                    SwapBlocksInColumn();
                    break;
                default:
                    MatrixTransposition();
                    break;
            }
        }

        public void SwapBlocksInColumn()
        {
            Random r = new Random();
            var block1 = r.Next(0, n);
            var block2 = r.Next(0, n);
            while (block1 == block2)
                block2 = r.Next(0, n);
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + n; j++)
                {
                    var temp = _map[i, j];
                    _map[i, j] = _map[i, k];
                    _map[i, k] = temp;
                    k++;
                }
            }
        }

        public void SwapBlocksInRow()
        {
            Random r = new Random();
            var block1 = r.Next(0, n);
            var block2 = r.Next(0, n);
            while (block1 == block2)
                block2 = r.Next(0, n);
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + n; j++)
                {
                    var temp = _map[j, i];
                    _map[j, i] = _map[k, i];
                    _map[k, i] = temp;
                    k++;
                }
            }
        }

        public void SwapRowsInBlock()
        {
            Random r = new Random();
            var block = r.Next(0, n);
            var row1 = r.Next(0, n);
            var line1 = block * n + row1;
            var row2 = r.Next(0, n);
            while (row1 == row2)
                row2 = r.Next(0, n);
            var line2 = block * n + row2;
            for (int i = 0; i < n * n; i++)
            {
                var temp = _map[line1, i];
                _map[line1, i] = _map[line2, i];
                _map[line2, i] = temp;
            }
        }

        public void SwapColumnsInBlock()
        {
            Random r = new Random();
            var block = r.Next(0, n);
            var row1 = r.Next(0, n);
            var line1 = block * n + row1;
            var row2 = r.Next(0, n);
            while (row1 == row2)
                row2 = r.Next(0, n);
            var line2 = block * n + row2;
            for (int i = 0; i < n * n; i++)
            {
                var temp = _map[i, line1];
                _map[i, line1] = _map[i, line2];
                _map[i, line2] = temp;
            }
        }

        public void MatrixTransposition()
        {
            int[,] tMap = new int[n * n, n * n];
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    tMap[i, j] = _map[j, i];
                }
            }
            _map = tMap;
        }

        public int[,] HideCells(int count)
        {
            int[,] map = new int[9,9];
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    map[i,j] = _map[j, i];
                }
            }
            while (count > 0)
            {
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        if (map[i, j] != 0)
                        {
                            int a = RandomProvider.RandomNext(0, 2);
                            map[i, j] = a == 0 ? 0 : _map[i, j];
                            if (map[i, j] == 0) count--;
                        }
                        if (count <= 0) break;
                    }
                    if (count <= 0) break;
                }
            }
            
            return map;
        }
    }
}

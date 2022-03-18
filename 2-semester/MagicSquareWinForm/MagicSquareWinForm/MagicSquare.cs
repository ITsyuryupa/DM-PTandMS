using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace MagicSquareWinForm
{
    internal class MagicSquare
    {
        static bool CheckSquare(int[,] square)
        {
            int n = square.GetLength(0);
            int[] Magic = new int[(2 * n + 2)];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Magic[i] += square[i, j];//пишем сумму строки
                    Magic[i + n] += square[j, i]; //пишем сумму столбца
                }
            }
            for (int j = 0; j < n; j++)
            {
                Magic[0 + 2 * n] += square[j, j];//пишем сумму диагонали главной
                Magic[1 + 2 * n] += square[j, (n - j - 1)];//пишем сумму диагонали побочной
            }
            bool proverka = true;
            for (int i = 1; i < Magic.Length; i++)
            {
                if (Magic[0] != Magic[i])
                {
                    proverka = false;
                    break;
                }
            }
            return proverka;
        }
        public static int[,] Odd(int n)
        {
            int[,] square = new int[n, n];
            int i = n / 2;
            int j = n - 1;
            for (int num = 1; num <= n * n;)
            {
                if (i == -1 && j == n)
                {
                    j = n - 2;
                    i = 0;
                }
                else
                {
                    if (j == n)
                        j = 0;
                    if (i < 0)
                        i = n - 1;
                }
                if (square[i, j] != 0)
                {
                    j -= 2;
                    i++;
                    continue;
                }
                else
                    square[i, j] = num++;
                j++; i--;
            }
            return square;
        }
        public static int[,] DoublyEven(int n)
        {
            int i, j;
            int[,] square = new int[n, n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    square[i, j] = (n * i) + j + 1;
                }
            }
            for (i = 0; i < n / 4; i++)
            {
                for (j = 0; j < n / 4; j++)
                {
                    square[i, j] = (n * n + 1) - square[i, j];
                }
            }
            for (i = 0; i < n / 4; i++)
            {
                for (j = 3 * (n / 4); j < n; j++)
                {
                    square[i, j] = (n * n + 1) - square[i, j];
                }
            }
            for (i = 3 * n / 4; i < n; i++)
            {
                for (j = 0; j < n / 4; j++)
                {
                    square[i, j] = (n * n + 1) - square[i, j];
                }
            }
            for (i = 3 * n / 4; i < n; i++)
            {
                for (j = 3 * n / 4; j < n; j++)
                {
                    square[i, j] = (n * n + 1) - square[i, j];
                }
            }
            for (i = n / 4; i < 3 * n / 4; i++)
            {
                for (j = n / 4; j < 3 * n / 4; j++)
                {
                    square[i, j] = (n * n + 1) - square[i, j];
                }
            }
            return square;
        }
        public static int[,] SinglyEven(int n)
        {
            int size = n * n;
            int halfN = n / 2;
            int subSquareSize = size / 4;
            int[,] subSquare = Odd(halfN);
            int[] quadrantFactors = { 0, 2, 3, 1 };
            int[,] square = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    int quadrant = (i / halfN) * 2 + (j / halfN);
                    square[i, j] = subSquare[i % halfN, j % halfN];
                    square[i, j] += quadrantFactors[quadrant] * subSquareSize;
                }
            int nColsLeft = halfN / 2;
            int nColsRight = nColsLeft - 1;
            for (int i = 0; i < halfN; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < nColsLeft || j >= n - nColsRight
                        || (j == nColsLeft && i == nColsLeft))
                    {
                        if (j == 0 && i == nColsLeft)
                        {
                            continue;
                        }
                        int tmp = square[i, j];
                        square[i, j] = square[i + halfN, j];
                        square[i + halfN, j] = tmp;
                    }
                }
            }
            return square;
        }
        public static void PrintMagicSquare(int[,] square, DataGridView grid, RichTextBox t)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();
            double a = 30 / Math.Log(square.GetLength(0));
            
            grid.RowsDefaultCellStyle.Font = new Font("Tahoma", 20);
            grid.DefaultCellStyle.Font = new Font("Tahoma", (int)a);
            for (int i = 0; i < square.GetLength(0); i++)
            {
                
                
                grid.Columns.Add(i.ToString(), i.ToString());
                grid.Rows.Add();
            }
            
            for (int i = 0; i < square.GetLength(0); i++)
            {
                
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    grid[j, i].Value = square[i, j]; 
                    
                }
                
            }
            int n = square.GetLength(0);
            

            int N = ((n * (n * n + 1)) / 2);
            if (CheckSquare(square))
            {
                t.Text = $"n = {n}" + "\nмагическое число =" + N.ToString() +"\nЭто магический квадрат";
            }
            else
            {
                t.Text = "Не Correct(";
            }
        }  

        public static void ScanSquare(DataGridView grid, RichTextBox t)
        {
            bool corrrectInput = true;
            bool IsNumberNow = true;
            int[,] square = new int[grid.ColumnCount, grid.ColumnCount];
            for (int i = 0; i < grid.ColumnCount; i++)
            {

                for (int j = 0; j < grid.ColumnCount; j++)
                {
                    try
                    {
                        square[i, j] = int.Parse(grid[j, i].Value.ToString());
                        
                    }
                    catch 
                    {
                        corrrectInput = false;
                        
                        grid[j, i].Value = 0;

                    }

                    
                    if (square[i, j] < 1)
                    {
                        corrrectInput = false;
                        square[i, j] = 0;
                        grid[j, i].Value = 0;
                    }
                }
            }

            if (!corrrectInput)
            {
                MessageBox.Show("вводить можно только числа больше 1");
            }

            int n = square.GetLength(0);
            int N = ((n * (n * n + 1)) / 2);
            if (CheckSquare(square))
            {
                t.Text = $"n = {n}" + "\nмагическое число =" + N.ToString() + "\nЭто магический квадрат";
            }
            else
            {
                t.Text = "Не Correct(";
            }
        }

        

    }
}

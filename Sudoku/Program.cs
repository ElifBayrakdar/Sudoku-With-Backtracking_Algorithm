using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
                {
                    //{3, 0, 6, 5, 0, 8, 4, 0, 0},
                    //{5, 2, 0, 0, 0, 0, 0, 0, 0},
                    //{0, 8, 7, 0, 0, 0, 0, 3, 1},
                    //{0, 0, 3, 0, 1, 0, 0, 8, 0},
                    //{9, 0, 0, 8, 6, 3, 0, 0, 5},
                    //{0, 5, 0, 0, 9, 0, 6, 0, 0},
                    //{1, 3, 0, 0, 0, 0, 2, 5, 0},
                    //{0, 0, 0, 0, 0, 0, 0, 7, 4},
                    //{0, 0, 5, 2, 0, 6, 3, 0, 0}

                    {0, 0, 1, 0, 0, 2, 0, 0, 0},
                    {6, 3, 4, 0, 0, 0, 5, 0, 0},
                    {0, 9, 0, 0, 8, 4, 0, 0, 0},
                    {0, 6, 7, 0, 0, 0, 1, 0, 5},
                    {0, 0, 0, 1, 5, 0, 0, 0, 0},
                    {0, 0, 0, 0, 7, 0, 8, 2, 3},
                    {0, 0, 3, 8, 0, 6, 2, 4, 0},
                    {0, 0, 6, 7, 0, 1, 0, 0, 0},
                    {0, 4, 0, 2, 0, 0, 7, 0, 9}
                };

            if (Solve(arr))
            {
                Print(arr);
            }
            else
            {
                Console.WriteLine("There aren't any solution!");
            }

            Console.ReadKey();
        }

        public static void Print(int[,] arr)
        {
            int length = arr.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("{0}, ", arr[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsPlaceOk(int num, int[,] arr, int rowIndex, int columnIndex, int length)
        {
            // row
            for (int i = 0; i < length; i++)
            {
                if (arr[rowIndex, i] == num)
                    return false;
            }

            // column
            for (int i = 0; i < length; i++)
            {
                if (arr[i, columnIndex] == num)
                    return false;
            }

            // nxn area
            int k = (rowIndex / 3) * 3;
            int m = (columnIndex / 3) * 3;

            for (int i = k; i < k + 3; i++)
            {
                for (int j = m; j < m + 3; j++)
                {
                    if (arr[i, j] == num)
                        return false;
                }
            }
            return true;
        }

        public static bool FindEmptyLocation(int[,] arr, out int row, out int col, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return true;
                    }
                }
            }
            row = 0;
            col = 0;
            return false;
        }

        public static bool Solve(int[,] arr)
        {
            int length = arr.GetLength(0);
            int row;
            int col;

            if (FindEmptyLocation(arr, out row, out col, length))
            {
                for (int k = 1; k <= length; k++)
                {
                    if (IsPlaceOk(k, arr, row, col, length))
                    {
                        arr[row, col] = k;

                        if (Solve(arr))
                        {
                            return true;
                        }
                        else
                        {
                            arr[row, col] = 0;
                        }
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

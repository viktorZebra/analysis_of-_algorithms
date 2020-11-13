using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    static class MultMatrix
    {
        public static int[][] Standart(int[][] matr1, int[][] matr2)
        {
            int row1 = matr1.Length;
            int row2 = matr2.Length;

            if (row1 == 0 || row2 == 0)
            {
                return null;
            }

            int col1 = matr1[0].Length;
            int col2 = matr2[0].Length;

            if (col1 != row2)
            {
                return null;
            }

            int[][] result = new int[row1][];
            for (int i = 0; i < row1; i++)
            {
                result[i] = new int[col2];
            }

            for (int i = 0; i < row1; i++)
                for (int j = 0; j < col2; j++)
                    for (int k = 0; k < col1; k++)
                    {
                        result[i][j] += matr1[i][k] * matr2[k][j];
                    }

            return result;
        }

        public static int[][] Vinograd(int[][] matr1, int[][] matr2)
        {
            int row1 = matr1.Length;
            int row2 = matr2.Length;

            if (row1 == 0 || row2 == 0)
                return null;

            int col1 = matr1[0].Length;
            int col2 = matr2[0].Length;

            if (col1 != row2)
                return null;

            int[] mulH = new int[row1];
            int[] mulV = new int[col2];

            int[][] res = new int[row1][];
            for (int i = 0; i < row1; i++)
                res[i] = new int[col2];

            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col1 / 2; j++)
                {
                    mulH[i] = mulH[i] + matr1[i][j * 2] * matr1[i][j * 2 + 1];
                }
            }

            for (int i = 0; i < col2; i++)
            {
                for (int j = 0; j < row2 / 2; j++)
                {
                    mulV[i] = mulV[i] + matr2[j * 2][i] * matr2[j * 2 + 1][i];
                }
            }

            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    res[i][j] = -mulH[i] - mulV[j];
                    for (int k = 0; k < col1 / 2; k++)
                    {
                        res[i][j] = res[i][j] + (matr1[i][2 * k + 1] + matr2[2 * k][j]) * (matr1[i][2 * k] + matr2[2 * k + 1][j]);
                    }
                }
            }

            if (col1 % 2 == 1)
            {
                for (int i = 0; i < row1; i++)
                {
                    for (int j = 0; j < col2; j++)
                    {
                        res[i][j] = res[i][j] + matr1[i][col1 - 1] * matr2[col1 - 1][j];
                    }
                }
            }

            return res;
        }

        public static int[][] ModVinograd(int[][] matr1, int[][] matr2)
        {
            int row1 = matr1.Length;
            int row2 = matr2.Length;

            if (row1 == 0 || row2 == 0)
                return null;

            int col1 = matr1[0].Length;
            int col2 = matr2[0].Length;

            if (col1 != row2)
                return null;

            int[] mulH = new int[row1];
            int[] mulV = new int[col2];

            int[][] res = new int[row1][];
            for (int i = 0; i < row1; i++)
                res[i] = new int[col2];

            int col1Mod2 = col1 % 2;
            int row2Mod2 = row2 % 2;

            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < (col1 - col1Mod2); j += 2)
                {
                    mulH[i] += matr1[i][j] * matr1[i][j + 1];
                }
            }

            for (int i = 0; i < col2; i++)
            {
                for (int j = 0; j < (row2 - row2Mod2); j += 2)
                {
                    mulV[i] += matr2[j][i] * matr2[j + 1][i];
                }
            }

            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    int buff = -(mulH[i] + mulV[j]);
                    for (int k = 0; k < (col1 - col1Mod2); k += 2)
                    {
                        buff += (matr1[i][k + 1] + matr2[k][j]) * (matr1[i][k] + matr2[k + 1][j]);
                    }
                    res[i][j] = buff;
                }
            }

            if (col1Mod2 == 1)
            {
                int col1Min_1 = col1 - 1;
                for (int i = 0; i < row1; i++)
                {
                    for (int j = 0; j < col2; j++)
                    {
                        res[i][j] += matr1[i][col1Min_1] * matr2[col1Min_1][j];
                    }
                }
            }

            return res;
        }
    }
}

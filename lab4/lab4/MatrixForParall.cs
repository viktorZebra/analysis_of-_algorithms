using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class MatrixForParall
    {
        public int[][] res, matr1, matr2;
        public int[] mulV, mulH;
        public int start, end, col1, col2;

        public MatrixForParall(int[][] res, int[][] matr1, int[][] matr2, int[] mulV, int[] mulH, int start, int end, int col1, int col2)
        {
            this.res = res;
            this.matr1 = matr1;
            this.matr2 = matr2;
            this.mulV = mulV;
            this.mulH = mulH;
            this.start = start;
            this.end = end;
            this.col1 = col1;
            this.col2 = col2;
        }

        public static void MainCycle(object obj)
        {
            MatrixForParall p = (MatrixForParall)obj;

            for (int i = p.start; i < p.end; i++)
            {
                for (int j = 0; j < p.col2; j++)
                {
                    p.res[i][j] = -p.mulH[i] - p.mulV[j];
                    for (int k = 0; k < p.col1 / 2; k++)
                    {
                        p.res[i][j] = p.res[i][j] + (p.matr1[i][2 * k + 1] + p.matr2[2 * k][j]) * (p.matr1[i][2 * k] + p.matr2[2 * k + 1][j]);
                    }
                }
            }
        }

        public static void MainCycleOptimize(object obj)
        {
            MatrixForParall p = (MatrixForParall)obj;
            int[][] res = p.res, matr1 = p.matr1, matr2 = p.matr2;
            int[] mulH = p.mulH, mulV = p.mulV;
            int start = p.start, end = p.end;
            int col2 = p.col2, col1 = p.col1;

            for (int i = start; i < end; i++)
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
        }
    }
}

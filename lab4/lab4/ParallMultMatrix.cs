using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace lab4
{
    class ParallMultMatrix
    {
        public static int[][] ParallelMultVin(int[][] matr1, int[][] matr2, int nThreads, int flag)
        {
            Thread[] threadsArray = new Thread[nThreads];

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

            int rowsForThread = row1 / nThreads;
            int start = 0;
            for (int i = 0; i < nThreads; i++)
            {
                int end = start + rowsForThread;

                if (i == nThreads - 1)
                    end = row1;

                MatrixForParall p = new MatrixForParall(res, matr1, matr2, mulV, mulH, start, end, col1, col2);

                if (flag == 1)
                    threadsArray[i] = new Thread(new ParameterizedThreadStart(MatrixForParall.MainCycleOptimize));
                else
                    threadsArray[i] = new Thread(new ParameterizedThreadStart(MatrixForParall.MainCycle));
                threadsArray[i].Start(p);

                start = end;
            }
            foreach (Thread thread in threadsArray)
            {
                thread.Join();
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
    }
}

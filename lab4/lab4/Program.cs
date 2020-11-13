using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace lab4
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Time(8, FillMatr, "Vin0.txt", 0, 0);
            Time(8, FillMatr, "Vin1.txt", 1, 0);
            Time(8, FillMatr, "VinOpt0.txt", 0, 1);
            Time(8, FillMatr, "VinOpt1.txt", 1, 1);
        }

        static void Time(int nThreads, Func<int, int, int[][]> genFunc, string filename, int flag, int flagOp)
        {

            int N_REP = 5;
            Stopwatch stopWatch = new Stopwatch();
            List<string> lines = new List<string>();

            for (int size = 100 + flag; size <= 500 + flag; size += 100)
            {
                long ts = 0;
                for (int repetitions = 1; repetitions <= N_REP; repetitions++)
                {
                    var a = genFunc(size, size);
                    var b = genFunc(size, size);
                    stopWatch.Start();

                    ParallMultMatrix.ParallelMultVin(a, b, nThreads, flagOp);

                    stopWatch.Stop();
                    ts += stopWatch.Elapsed.Milliseconds;
                }
                lines.Add(size.ToString() + " " + (ts / N_REP).ToString());
            }

            File.AppendAllLines(filename, lines);
        }

        public static int[][] FillMatr(int n, int m)
        {
            int[][] matr = new int[n][];
            int[] tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = new int[m];
                for (int j = 0; j < m; j++)
                    tmp[j] = rand.Next(1000);
                matr[i] = tmp;
            }
            return matr;
        }

        static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                    Console.Write(" ");
                }

                Console.Write('\n');
            }
        }
    }
}

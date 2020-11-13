using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace lab2
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            /*int row1 = Convert.ToInt32(Console.ReadLine());
            int col1 = Convert.ToInt32(Console.ReadLine());
            int row2 = Convert.ToInt32(Console.ReadLine());
            int col2 = Convert.ToInt32(Console.ReadLine());

            int[][] matr1 = new int[row1][];
            for (int i = 0; i < row1; i++)
            {
                matr1[i] = new int[col1];
            }

            int[][] matr2 = new int[row2][];
            for (int i = 0; i < row2; i++)
            {
                matr2[i] = new int[col2];
            }


            for (int i = 0; i < row1; i++)
                for (int j = 0; j < col1; j++)
                {
                    matr1[i][j] = Convert.ToInt32(Console.ReadLine());
                }

            for (int i = 0; i < row2; i++)
                for (int j = 0; j < col2; j++)
                {
                    matr2[i][j] = Convert.ToInt32(Console.ReadLine());
                }

            PrintMatrix(MultMatrix.Standart(matr1, matr2));
            PrintMatrix(MultMatrix.Vinograd(matr1, matr2));
            PrintMatrix(MultMatrix.ModVinograd(matr1, matr2));*/

            Time(MultMatrix.Standart, FillMatr, "Stand0.txt");
            Time(MultMatrix.Standart, FillMatr, "Stand1.txt", 1);
            Time(MultMatrix.Vinograd, FillMatr, "Vin0.txt");
            Time(MultMatrix.Vinograd, FillMatr, "Vin1.txt", 1);
            Time(MultMatrix.ModVinograd, FillMatr, "VinOpt0.txt");
            Time(MultMatrix.ModVinograd, FillMatr, "VinOpt1.txt", 1);
        }

        static void Time(Func<int[][], int[][], int[][]> multFunc, Func<int, int, int[][]> genFunc, string filename, int flag = 0)
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

                    multFunc(a, b);

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

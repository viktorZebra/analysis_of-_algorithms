using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace lab3
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Time(Sort.Bouble, FillMatr, "Bouble.txt");
            Time(Sort.Insert, FillMatr, "Insert.txt");
            Time(Sort.Selection, FillMatr, "Selection.txt");
        }

        static void Time(Func<int[], int[]> sortFunc, Func<int, int[]> genFunc, string filename, int flag = 0)
        {

            int N_REP = 5;
            Stopwatch stopWatch = new Stopwatch();
            List<string> lines = new List<string>();

            for (int size = 100 + flag; size <= 1000 + flag; size += 100)
            {
                long ts = 0;
                for (int repetitions = 1; repetitions <= N_REP; repetitions++)
                {
                    var a = genFunc(size);
                    stopWatch.Start();

                    sortFunc(a);

                    stopWatch.Stop();
                    ts += stopWatch.Elapsed.Milliseconds;
                }
                lines.Add(size.ToString() + " " + (ts / N_REP).ToString());
            }

            File.AppendAllLines(filename, lines);
        }

        public static int[] FillMatr(int n)
        {
            int[] matr = new int[n];

            for (int i = 0; i < n; i++)
            {
                matr[i] = rand.Next(1000);
            }
            return matr;
        }
    }
}

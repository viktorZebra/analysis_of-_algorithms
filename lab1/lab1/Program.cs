using System;
using System.Diagnostics;
using System.IO;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Levenshtein.LevenshteinDistance("", ""));
            /*Stopwatch stopWatch = new Stopwatch();
            StreamWriter sw = new StreamWriter(@"C:\Student_work\C#\AnAl\lab1\lab1\timeAlg.txt", true);

            string s1_1 = "uvigSJRewq";
            string s1_2 = "11C9aduDSp";

            string s2_1 = "dtoWa0v";
            string s2_2 = "DJPpt6i";

            string s3_1 = "zFopf";
            string s3_2 = "ryrqn";

            string s4_1 = "pxc";
            string s4_2 = "RvO";

            double[] array = new double[4];
            stopWatch.Start();
            Levenshtein.LevenshteinDistance(s4_1, s4_2);
            stopWatch.Stop();
            array[0] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.LevenshteinDistance(s3_1, s3_2);
            stopWatch.Stop();
            array[1] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.LevenshteinDistance(s2_1, s2_2);
            stopWatch.Stop();
            array[2] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.LevenshteinDistance(s1_1, s1_2);
            stopWatch.Stop();
            array[3] = stopWatch.Elapsed.TotalMilliseconds;
            sw.WriteLine($"{array[0]}, {array[1]}, {array[2]}, {array[3]}");


            stopWatch.Restart();
            Levenshtein.RLevenshteinDistance(s4_1, s4_2);
            stopWatch.Stop();
            array[0] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.RLevenshteinDistance(s3_1, s3_2);
            stopWatch.Stop();
            array[1] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.RLevenshteinDistance(s2_1, s2_2);
            stopWatch.Stop();
            array[2] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.RLevenshteinDistance(s1_1, s1_2);
            stopWatch.Stop();
            array[3] = stopWatch.Elapsed.TotalMilliseconds;
            sw.WriteLine($"{array[0]}, {array[1]}, {array[2]}, {array[3]}");


            stopWatch.Restart();
            Levenshtein.RMLevenshteinDistance(s4_1, s4_2);
            stopWatch.Stop();
            array[0] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.RMLevenshteinDistance(s3_1, s3_2);
            stopWatch.Stop();
            array[1] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.RMLevenshteinDistance(s2_1, s2_2);
            stopWatch.Stop();
            array[2] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.RMLevenshteinDistance(s1_1, s1_2);
            stopWatch.Stop();
            array[3] = stopWatch.Elapsed.TotalMilliseconds;
            sw.WriteLine($"{array[0]}, {array[1]}, {array[2]}, {array[3]}");


            stopWatch.Restart();
            Levenshtein.DamerauLevenshteinDistance(s4_1, s4_2);
            stopWatch.Stop();
            array[0] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.DamerauLevenshteinDistance(s3_1, s3_2);
            stopWatch.Stop();
            array[1] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.DamerauLevenshteinDistance(s2_1, s2_2);
            stopWatch.Stop();
            array[2] = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            Levenshtein.DamerauLevenshteinDistance(s1_1, s1_2);
            stopWatch.Stop();
            array[3] = stopWatch.Elapsed.TotalMilliseconds;
            sw.WriteLine($"{array[0]} {array[1]} {array[2]} {array[3]}");

            sw.Close();*/

        }
    }
}

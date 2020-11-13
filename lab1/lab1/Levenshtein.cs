using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace lab1
{
    public static class Levenshtein
    {
        public static int LevenshteinDistance(string firstWord, string secondWord)
        {
            int n = firstWord.Length + 1;
            int m = secondWord.Length + 1;
            int[,] matrixD = new int[n, m];

            int deletionCost = 1;
            int insertionCost = 1;

            InitMatrix(matrixD, n, m);

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    int replaceCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;

                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + deletionCost,          // удаление
                                            matrixD[i, j - 1] + insertionCost,         // вставка
                                            matrixD[i - 1, j - 1] + replaceCost);      // замена
                }
            }

            return matrixD[n - 1, m - 1];
        }

        private static int RLevenshteinDistance(string text1, int len1, string text2, int len2)
        {
            int deletionCost = 1;
            int insertionCost = 1;

            if (len1 == 0)
            {
                return len2;
            }

            if (len2 == 0)
            {
                return len1;
            }

            int replaceCost = text1[len1 - 1] == text2[len2 - 1] ? 0 : 1;

            int deletion = RLevenshteinDistance(text1, len1 - 1, text2, len2) + deletionCost;
            int insertion = RLevenshteinDistance(text1, len1, text2, len2 - 1) + insertionCost;
            int replace = RLevenshteinDistance(text1, len1 - 1, text2, len2 - 1) + replaceCost;

            return Minimum(deletion, insertion, replace);
        }

        private static int RMLevenshteinDistance(string text1, int len1, string text2, int len2)
        {
            int n = len1 + 1;
            int m = len2 + 1;

            int[,] matrixD = new int[n, m];

            RMInitMatrix(matrixD, n, m);

            fillMatrix(text1, n - 1, text2, m - 1, ref matrixD);

            return matrixD[n - 1, m - 1];
        }

        private static int fillMatrix(string text1, int i, string text2, int j, ref int[,] matrixD)
        {
            if (matrixD[i, j] != -1)
            {
                return matrixD[i, j];
            }

            int deletionCost = 1;
            int insertionCost = 1;
            int replaceCost = text1[i - 1] == text2[i - 1] ? 0 : 1;

            int deletion = fillMatrix(text1, i - 1, text2, j, ref matrixD) + deletionCost;
            int insertion = fillMatrix(text1, i, text2, j - 1, ref matrixD) + insertionCost;
            int replace = fillMatrix(text1, i - 1, text2, j - 1, ref matrixD) + replaceCost;

            matrixD[i, j] = Minimum(deletion, insertion, replace);

            return matrixD[i, j];
        }

        public static int DamerauLevenshteinDistance(string firstWord, string secondWord)
        {
            int deletionCost = 1;
            int insertionCost = 1;

            int n = firstWord.Length + 1;
            int m = secondWord.Length + 1;
            int[,] matrixD = new int[n, m];

            InitMatrix(matrixD, n, m);

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    int replaceCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;

                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + deletionCost,         // удаление
                                            matrixD[i, j - 1] + insertionCost,        // вставка
                                            matrixD[i - 1, j - 1] + replaceCost);     // замена

                    if (i > 1 && j > 1
                        && firstWord[i - 1] == secondWord[j - 2]
                        && firstWord[i - 2] == secondWord[j - 1])
                    {
                        matrixD[i, j] = Minimum(matrixD[i, j],
                                                matrixD[i - 2, j - 2] + 1);           // перестановка
                    }
                }
            }

            return matrixD[n - 1, m - 1];
        }

        public static int RLevenshteinDistance(string firstWord, string secondWord) =>
                          RLevenshteinDistance(firstWord, firstWord.Length, secondWord, secondWord.Length);

        public static int RMLevenshteinDistance(string firstWord, string secondWord) =>
                          RMLevenshteinDistance(firstWord, firstWord.Length, secondWord, secondWord.Length);

        private static void InitMatrix(int [,] matrix, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[i, 0] = i;
            }

            for (int j = 0; j < m; j++)
            {
                matrix[0, j] = j;
            }
        }

        private static void RMInitMatrix(int[,] matrix, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        matrix[i, j] = i;
                    }
                    else if (i == 0)
                    {
                        matrix[i, j] = j;
                    }
                    else
                    {
                        matrix[i, j] = -1;
                    }
                }
            }
        }

        private static int Minimum(int a, int b, int c)
        {
            if (a > b)
            {
                a = b;
            }

            if (a > c)
            {
                a = c;
            }

            return a;
        }

        private static int Minimum(int a, int b)
        {
            return a < b ? a : b;
        }
    }
}

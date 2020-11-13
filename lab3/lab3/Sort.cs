using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    static class Sort
    {
        public static int[] Bouble(int[] mas)
        {
            bool flag = true;
            int len = mas.Length;

            for (int i = 0; i < len && flag; i++)
            {
                flag = false;
                for (int j = 0; j < len - i - 1; j++)
                {
                    if (myCmp(mas[j], mas[j + 1]))
                    {
                        int buf = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = buf;

                        flag = true;
                    }
                }
            }

            return mas;
        }

        public static int[] Insert(int[] mas)
        {
            int len = mas.Length;

            for (int i = 1; i < len; i++)
            {
                int val = mas[i];
                int j = i;

                while (j > 0 && myCmp(mas[j - 1], val))
                {
                    mas[j] = mas[j - 1];
                    j--;
                }

                mas[j] = val;
            }
            return mas;
        }

        public static int[] Selection(int[] mas)
        {
            int len = mas.Length;

            for (int i = 0; i < len; i++)
            {
                int minI = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (myCmp(mas[j], mas[i]))
                    {
                        minI = j;
                    }
                }

                int buf = mas[minI];
                mas[minI] = mas[i];
                mas[i] = buf;
            }
            return mas;
        }

        static bool myCmp(int a, int b)
        {
            if (a - b > 0)
                return true;
            else
                return false;
        }
    }
}

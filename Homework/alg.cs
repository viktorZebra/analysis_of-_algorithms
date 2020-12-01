(1)         for (int i = 0; i < row1; i++)
            {
(2)             for (int j = 0; j < (col1 - col1Mod2); j += 2)
                {
(3)                 mulH[i] += matr1[i][j] * matr1[i][j + 1];
                }
            }

(4)         for (int i = 0; i < col2; i++)
            {
(5)             for (int j = 0; j < (row2 - row2Mod2); j += 2)
                {
(6)                 mulV[i] += matr2[j][i] * matr2[j + 1][i];
                }
            }

(7)         for (int i = 0; i < row1; i++)
            {
(8)             for (int j = 0; j < col2; j++)
                {
(9)                 int buff = -(mulH[i] + mulV[j]);
(10)                for (int k = 0; k < (col1 - col1Mod2); k += 2)
                    {
(11)                    buff += (matr1[i][k + 1] + matr2[k][j]) * (matr1[i][k] + matr2[k + 1][j]);
                    }
(12)                res[i][j] = buff;
                }
            }

(13)        if (col1Mod2 == 1)
            {
(14)            int col1Min_1 = col1 - 1;
(15)            for (int i = 0; i < row1; i++)
                {
(16)                for (int j = 0; j < col2; j++)
                    {
(17)                    res[i][j] += matr1[i][col1Min_1] * matr2[col1Min_1][j];
                    }
                }
            }
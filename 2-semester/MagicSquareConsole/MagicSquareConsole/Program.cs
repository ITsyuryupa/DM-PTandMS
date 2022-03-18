// See https://aka.ms/new-console-template for more information
static void CheckSquare(int[,] square)
{
    int n = square.GetLength(0);
    int[] Magic = new int[(2 * n + 2)];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Magic[i] += square[i, j];//пишем сумму строки
            Magic[i + n] += square[j, i]; //пишем сумму столбца
        }
    }
    for (int j = 0; j < n; j++)
    {
        Magic[0 + 2 * n] += square[j, j];//пишем сумму диагонали главной
        Magic[1 + 2 * n] += square[j, (n - j - 1)];//пишем сумму диагонали побочной
    }
    bool proverka = true;
    for (int i = 1; i < Magic.Length; i++)
    {
        if (Magic[0] != Magic[i])
        {
            proverka = false;
            break;
        }
    }
    if (proverka == false)
        Console.WriteLine("Введённая матрица не является магическим квадратом.");
    else
        Console.WriteLine("Это магический квадрат!");
}




static int[,] Odd(int n)
{
    int[,] square = new int[n, n];
    int i = n / 2;
    int j = n - 1;
    for (int num = 1; num <= n * n;)
    {
        if (i == -1 && j == n)
        {
            j = n - 2;
            i = 0;
        }
        else
        {
            if (j == n)
                j = 0;
            if (i < 0)
                i = n - 1;
        }
        if (square[i, j] != 0)
        {
            j -= 2;
            i++;
            continue;
        }
        else
            square[i, j] = num++;
        j++; i--;
    }
    return square;
}
static int[,] DoublyEven(int n)
{
    int i, j;
    int[,] square = new int[n, n];
    for (i = 0; i < n; i++)
    {
        for (j = 0; j < n; j++)
        {
            square[i, j] = (n * i) + j + 1;
        }
    }
    for (i = 0; i < n / 4; i++)
    {
        for (j = 0; j < n / 4; j++)
        {
            square[i, j] = (n * n + 1) - square[i, j];
        }
    }
    for (i = 0; i < n / 4; i++)
    {
        for (j = 3 * (n / 4); j < n; j++)
        {
            square[i, j] = (n * n + 1) - square[i, j];
        }
    }
    for (i = 3 * n / 4; i < n; i++)
    {
        for (j = 0; j < n / 4; j++)
        {
            square[i, j] = (n * n + 1) - square[i, j];
        }
    }
    for (i = 3 * n / 4; i < n; i++)
    {
        for (j = 3 * n / 4; j < n; j++)
        {
            square[i, j] = (n * n + 1) - square[i, j];
        }
    }
    for (i = n / 4; i < 3 * n / 4; i++)
    {
        for (j = n / 4; j < 3 * n / 4; j++)
        {
            square[i, j] = (n * n + 1) - square[i, j];
        }
    }
    return square;
}
static int[,] SinglyEven(int n)
{
    int size = n * n;
    int halfN = n / 2;
    int subSquareSize = size / 4;
    int[,] subSquare = Odd(halfN);
    int[] quadrantFactors = { 0, 2, 3, 1 };
    int[,] square = new int[n, n];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
        {
            int quadrant = (i / halfN) * 2 + (j / halfN);
            square[i, j] = subSquare[i % halfN, j % halfN];
            square[i, j] += quadrantFactors[quadrant] * subSquareSize;
        }
    int nColsLeft = halfN / 2;
    int nColsRight = nColsLeft - 1;
    for (int i = 0; i < halfN; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (j < nColsLeft || j >= n - nColsRight
                || (j == nColsLeft && i == nColsLeft))
            {
                if (j == 0 && i == nColsLeft)
                {
                    continue;
                }
                int tmp = square[i, j];
                square[i, j] = square[i + halfN, j];
                square[i + halfN, j] = tmp;
            }
        }
    }
    return square;
}
static void PrintMagicSquare(int[,] square)
{
    int i, j;
    string s;
    for (i = 0; i < square.GetLength(0); i++)
    {
        s = "";
        for (j = 0; j < square.GetLength(1); j++)
        {
            if (square.Length > 10 && square[i, j] < 10) s += " ";
            if (square.Length > 100 && square[i, j] < 100) s += " ";
            s = s + square[i, j] + " ";
        }
        Console.WriteLine(s);
    }
    CheckSquare(square);
}





int n, i, j;
Console.WriteLine("Введите порядок квадрата ");
n = int.Parse(Console.ReadLine());
Console.WriteLine("Магическая сумма = " + (n * (n * n + 1)) / 2);
if (n % 2 == 1)
{
    //int[,] ary = odd(n);
    PrintMagicSquare(Odd(n));
}
else if (n % 4 == 0)
{
    //int[,] ary = DoublyEven(n);
    PrintMagicSquare(DoublyEven(n));
}
else if (n % 2 == 0)
{
    //int[,] ary = SinglyEven(n);
    PrintMagicSquare(SinglyEven(n));
}



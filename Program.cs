using static System.Console;

//Exercise1();
Exercise2();

void Exercise1()
{
    int[] masFirst = new int[5];
    double[][] masSecond = new double[4][];
    double Sum = 0;
    int? max = null;
    int? min = null;
    double product = 1;
    int sumEven = 0;
    double sumOddColumns = 0;

    for (int i = 0;i < masFirst.Length; i++)
    {
        Write("Введите целочисленное значение: ");
        masFirst[i] = int.Parse(ReadLine()); 
    }

    for (int i = 0; i < 4; i++)
    {
        masSecond[i] = new double[3];

        for (int j = 0;j < 3; j++)
        {
            masSecond[i][j] = i + j; 
        }
    }

    foreach(int i in masFirst)
    {
        product *= i;

        if(i % 2 == 0)
        {
            sumEven += i;
        }
        Write(i);
    }

    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Sum += masSecond[i][j];
            product *= masSecond[i][j];

            if (masFirst.Min() == masSecond[i][j])
            {
                min = masFirst.Min();
            }
            if (masFirst.Max() == masSecond[i][j])
            {
                max = masFirst.Max();
            }
            if (j % 2 != 0)
            {
                sumOddColumns += masSecond[i][j];
            }

            Write(masSecond[i][j]);
        }
        WriteLine();
    }
    Sum += masFirst.Sum();

    WriteLine($"\nОбщий максимум: {max}");
    WriteLine($"Общий минимум: {min}");
    WriteLine($"Общая сумма: {Sum}");
    WriteLine($"Общее произведение: {product}");
    WriteLine($"Сумма чётных элементов массива A: {sumEven}");
    WriteLine($"Сумма элементов нечётных столбцов массива B: {sumOddColumns}");

}

void Exercise2()
{
    int[][] mas = new int[5][];
    Random rand = new Random();
    int min = int.MaxValue, max = int.MinValue;
    int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;
    int value, sum = 0;

    for (int i = 0; i < 5; i++)
    {
        mas[i] = new int[5];
    }

    Console.WriteLine("Массив:");

    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            value = rand.Next(-100, 101);
            mas[i][j] = value;

            Console.Write($"{value,5}");

            if (value < min)
            {
                min = value;
                minRow = i;
                minCol = j;
            }
            if (value > max)
            {
                max = value;
                maxRow = i;
                maxCol = j;
            }
        }
        Console.WriteLine();
    }

    int minPos = minRow * 5 + minCol;
    int maxPos = maxRow * 5 + maxCol;

    if (minPos > maxPos)
    {
        int temp = minPos;
        minPos = maxPos;
        maxPos = temp;
    }

    for (int i = minPos + 1; i < maxPos; i++)
    {
        int row = i / 5;
        int col = i % 5;
        sum += mas[row][col];
    }

    Console.WriteLine($"\nМинимум: {min}, максимум: {max}");
    Console.WriteLine($"Сумма между ними: {sum}");
}
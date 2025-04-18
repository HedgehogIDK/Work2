using System.Text.RegularExpressions;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

Exercise1();
Exercise2();
//Для 3 задания
//Console.Write("Введите строку для шифрования: ");
//string input = Console.ReadLine();

//Console.Write("Введите сдвиг: ");
//int shift = int.Parse(Console.ReadLine());

//string encrypted = Exercise3(input, shift);

//Console.WriteLine($"Зашифрованная строка: {encrypted}");

//Для 5 задания
//Console.Write("Введите выражение (например: 5 + 2 - 3 + 10): ");
//string input = Console.ReadLine();

//int result = Exercise5(input);
//Console.WriteLine($"Результат: {result}");

//Для 6 задания

//Console.WriteLine("Введите текст:");
//string text = Console.ReadLine();

//string result = Exercise6(text);
//Console.WriteLine("\nРезультат:");
//Console.WriteLine(result);

Exercise7();

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

string Exercise3(string text, int shift)
{
    char[] result = new char[text.Length];

    for (int i = 0; i < text.Length; i++)
    {
        char c = text[i];
        if (char.IsLetter(c))
        {
            char baseChar = char.IsUpper(c) ? 'A' : 'a';
            result[i] = (char)((c - baseChar + shift) % 26 + baseChar);
        }
        else
        {
            result[i] = c;
        }
    }

    return new string(result);
}

int Exercise5(string expression)
{
    expression = expression.Replace(" ", "");
    MatchCollection matches = Regex.Matches(expression, @"[-+]?\d+");

    int sum = 0;
    foreach (Match match in matches)
    {
        sum += int.Parse(match.Value);
    }
    return sum;
}

string Exercise6(string input)
{
    string[] sentences = input.Split(new[] { '.', '!', '?' }, StringSplitOptions.None);
    string[] separators = Regex.Split(input, @"[^.!?]*[.!?]");

    for (int i = 0; i < sentences.Length; i++)
    {
        sentences[i] = sentences[i].TrimStart();
        if (!string.IsNullOrWhiteSpace(sentences[i]))
            sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
    }

    return string.Join(". ", sentences).Trim() + ".";
}

void Exercise7()
{
    string[] badWords = { "грубиян", "дурак", "мат", "брань" };

    Console.WriteLine("Введите текст:");

    string input = Console.ReadLine();

    string pattern = @"\b(" + string.Join("|", badWords) + @")\b";
    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

    HashSet<string> foundWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    int replacementCount = 0;

    string result = regex.Replace(input, match =>
    {
        foundWords.Add(match.Value.ToLower());
        replacementCount++;
        return new string('*', match.Value.Length);
    });

    Console.WriteLine("\n--- Результат ---");
    Console.WriteLine("Обработанный текст:\n" + result);

    Console.WriteLine("\n--- Статистика ---");
    Console.WriteLine($"Заменено слов: {replacementCount}");
    Console.WriteLine("Список заменённых слов: " + (foundWords.Count > 0 ? string.Join(", ", foundWords) : "нет"));
}
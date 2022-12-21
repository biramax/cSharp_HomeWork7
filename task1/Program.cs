/*

Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9

*/

// Получает целое число от пользователя
int GetNumber(string message, bool notNull = false, bool notNegative = false, bool lowestValueExists = false, int lowestValue = 0)
{
    bool isCorrect = false;
    int number = 0;

    while (!isCorrect)
    {
        Console.Write(message+": ");
        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out number))
        {
            if (notNull && number == 0)
                Console.WriteLine("Число не должно быть равно нулю.");
            
            else if (notNegative && number < 0)
                Console.WriteLine("Число должно быть положительным.");
            
            else if (lowestValueExists && number <= lowestValue)
                Console.WriteLine($"Число должно быть больше {lowestValue}.");
            
            else
                isCorrect = true;
        }
            
        else
            Console.WriteLine(input.Trim() == "" ? "Вы ничего не ввели." : "Вы ввели некорректные данные.");
    }
    
    return number;
}

// Генерирует матрицу из случайных вещественных чисел
double[,] InitMatrix(int rows, int columns, int min, int max)
{
    double[,] matrix = new double[rows, columns];
    Random rnd = new Random();
    double a;

    for (int i = 0; i < matrix.GetLength(0); i ++)
    {
        for (int j = 0; j < matrix.GetLength(1); j ++)
        {
            a = rnd.NextDouble(); // NextDouble() дает случайное вещественное число в диапазоне от 0 до 1
            matrix[i, j] = Math.Round(rnd.Next(min, max) + a, 2); // Не прибавляем 1 к max, т.к. к нему прибавляется дробная часть
        }
    }

    return matrix;
}

// Выводит матрицу в консоль
void PrintMatrix(string message, double[,] matrix)
{
    Console.WriteLine(message+":");

    for (int i = 0; i < matrix.GetLength(0); i ++)
    {
        for (int j = 0; j < matrix.GetLength(1); j ++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}



Console.WriteLine("================================");

int rows    = GetNumber("Введите количество строк матрицы", notNull: true, notNegative: true);
int columns = GetNumber("Введите количество столбцов матрицы", notNull: true, notNegative: true);
int min     = GetNumber("Введите минимальное значение элементов матрицы");
int max     = GetNumber("Введите максимальное значение элементов матрицы", lowestValueExists: true, lowestValue: min);

double[,] matrix = InitMatrix(rows, columns, min, max);

Console.WriteLine();
PrintMatrix("Сгенерированная матрица из случайных вещественных чисел", matrix);

Console.WriteLine("================================");
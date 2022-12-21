/*

Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

17 -> такого числа в массиве нет

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

// Генерирует матрицу из случайных чисел
int[,] InitMatrix(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i ++)
    {
        for (int j = 0; j < matrix.GetLength(1); j ++)
            matrix[i,j] = rnd.Next(min, max + 1);
    }

    return matrix;
}

// Выводит матрицу в консоль
void PrintMatrix(string message, int[,] matrix)
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

// Выводит значение элемента с указанной позицией в матрице
void PrintElementValue(int[,] matrix, int i, int j) 
{   
    int numRows = matrix.GetLength(0);
    int numCols = matrix.GetLength(1);

    if (i < numRows && j < numCols)
        Console.WriteLine("Значение элемента с позицией ["+i+", "+j+"] в матрице: "+matrix[i, j]+".");
    else
        Console.WriteLine("Элемента с указанной позицией в матрице нет.");
}


Console.WriteLine("================================");

int rows    = GetNumber("Введите количество строк матрицы", notNull: true, notNegative: true);
int columns = GetNumber("Введите количество столбцов матрицы", notNull: true, notNegative: true);
int min     = GetNumber("Введите минимальное значение элементов матрицы");
int max     = GetNumber("Введите максимальное значение элементов матрицы", lowestValueExists: true, lowestValue: min);

int[,] matrix = InitMatrix(rows, columns, min, max);

Console.WriteLine();
PrintMatrix("Сгенерированная матрица", matrix);
Console.WriteLine();

int i = GetNumber("Введите индекс строки элемента");
int j = GetNumber("Введите индекс столбца элемента");

Console.WriteLine();
PrintElementValue(matrix, i, j);

Console.WriteLine("================================");

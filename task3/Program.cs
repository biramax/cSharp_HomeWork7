﻿/*

Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

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
            matrix[i, j] = rnd.Next(min, max + 1);
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

// Выводит среднее арифметическое элементов в каждом столбце
void PrintColumnsAverage(int[,] matrix) 
{   
    int numRows    = matrix.GetLength(0);
    int numColumns = matrix.GetLength(1);
    double average    = 0;

    for (int j = 0; j < numColumns; j ++)
    {
        average = 0;
        
        for (int i = 0; i < numRows; i ++)
        {
            average += matrix[i, j];
        }
        
        Console.WriteLine(Math.Round(average / Convert.ToDouble(numRows), 2));
    }
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

Console.WriteLine("Среднее арифметическое по столбцам: ");
PrintColumnsAverage(matrix);

Console.WriteLine("================================");

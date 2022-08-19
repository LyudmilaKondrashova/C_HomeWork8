// Задача 54: Задайте двумерный массив. Напишите программу, которая
// упорядочит по убыванию элементы каждой строки двумерного массива.
void Zadacha54()
{
    Random random = new Random();
    int rows = random.Next(4, 8);
    int columns = random.Next(4, 8);
    int[,] array = new int[rows, columns];

    Console.WriteLine("Исходный массив");
    FillArray(array, -100, 100);
    PrintArray(array);
    SortOneArray(array);
    Console.WriteLine("Отсортированный массив");
    PrintArray(array);
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите
// программу, которая будет находить строку с наименьшей суммой элементов.
//СТРОКИ И СТОЛБЦЫ СЧИТАЕМ С 0
void Zadacha56()
{
    Random random = new Random();
    int rows = random.Next(3, 5);
    int columns = random.Next(3, 5);
    int[,] array = new int[rows, columns];

    Console.WriteLine("Исходный массив");
    FillArray(array, -10, 10);
    PrintArray(array);

    int minSum = 0;
    int indMinSum = 0;
    for (int j = 0; j < columns; j++)
        minSum += array[0, j];
    for (int i = 1; i < rows; i++)
    {
        int sum = 0;
        for (int j = 0; j < columns; j++)
            sum += array[i, j];
        if (sum < minSum)
        {
            minSum = sum;
            indMinSum = i;
        }
    }

    Console.WriteLine($"Строка номер {indMinSum} с наименьшeй суммой элементов, равной {minSum}:");
    PrintRowArray(array, indMinSum);
}

// Задача 58: Заполните спирально массив 4 на 4 числами от 1 до 16.
void Zadacha58()
{
    int size = 4;
    int[,] array = new int[size, size];
    bool flag = true;
    int count = 1;
    int i = 0;

    while (count <= size * size)
    {
        if (flag)
        {
            for (int j = i; j < size - i; j++)
            {
                array[i, j] = count;
                count++;
            }
            for (int k = i + 1; k < size - i; k++)
            {
                array[k, size - i - 1] = count;
                count++;
            }
            flag = !flag;
        }
        else
        {
            for (int j = size - i - 2; j >= i; j--)
            {
                array[size - i - 1, j] = count;
                count++;
            }
            for (int k = size - i - 2; k > i; k--)
            {
                array[k, i] = count;
                count++;
            }
            flag = !flag;
            i++;
        }
    }
    PrintArray(array);
}

// Задача 61: Задайте две матрицы. Напишите программу, которая будет
// находить произведение двух матриц.
void Zadacha61()
{
    Random random = new Random();
    int rows = random.Next(2, 5);
    int columns1 = random.Next(2, 5);
    int columns2 = random.Next(2, 5);
    int[,] array1 = new int[rows, columns1];
    int[,] array2 = new int[columns1, columns2];
    int[,] arrayPr = new int[rows, columns2];

    Console.WriteLine("Первый массив ");
    FillArray(array1, 0, 5);
    PrintArray(array1);
    Console.WriteLine("Второй массив ");
    FillArray(array2, 0, 5);
    PrintArray(array2);

    for (int i = 0; i < rows; i++)
    {
        for (int k = 0; k < columns2; k++)
        {
            int Pr = 0;
            for (int j = 0; j < columns1; j++)
                Pr += array1[i, j] * array2[j, k];
            arrayPr[i, k] = Pr;
        }
    }

    Console.WriteLine("Произведение матриц");
    PrintArray(arrayPr);
}

// Заполнение массива
void FillArray(int[,] array, int startNumber = 0, int finishNumber = 9)
{
    Random random = new Random();
    finishNumber++;
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = random.Next(startNumber, finishNumber);
        }
    }
}

//Печать массива
void PrintArray(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

//Сортировка по убыванию элементов в каждой строке массива
void SortOneArray(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns - 1; j++)
        {
            int MinEl = array[i, 0];
            int IndMinEl = 0;
            for (int k = 1; k < columns - j; k++)
            {
                if (array[i, k] < MinEl)
                {
                    MinEl = array[i, k];
                    IndMinEl = k;
                }
            }
            int temp = array[i, columns - j - 1];
            array[i, columns - j - 1] = MinEl;
            array[i, IndMinEl] = temp;
        }
    }
}

//Печать строки массива
void PrintRowArray(int[,] array, int numbRow)
{
    int columns = array.GetLength(1);

    for (int j = 0; j < columns; j++)
    {
        Console.Write(array[numbRow, j] + "\t");
    }
    Console.WriteLine();
}

Zadacha54();
Zadacha56();
Zadacha58();
Zadacha61();
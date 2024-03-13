using System;
using System.Linq;

class MainClass
{
    //Лабораторная2, Вариант 16
    //Путем перестановки элементов квадратной вещественной матрицы добиться того,
    //чтобы ее максимальный элемент находился в левом верхнем углу, следующий по величине — в позиции (2, 2) , следующий по величине — в позиции (3, 3) и т. д.,
    //заполнив таким образом всю главную диагональ.
    //Найти номер первой из строк, не содержащих ни одного положительного элемента.

    public static void Main(string[] args)
    {
        int size = 5;
        int[,] matrix = new int[size, size];
        Random rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = rnd.Next(-20, 11);
            }
        }

        PrintMatrix(matrix);
        Console.WriteLine(" ");
        PrintFirstNoPositive(matrix);
        Console.WriteLine(" ");
        PrintMatrix(TransformMatrix(matrix));
        Console.WriteLine(" ");
        PrintFirstNoPositive(TransformMatrix(matrix));
    }


    static void PrintMatrix(int[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                Console.Write(m[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int[,] TransformMatrix(int[,] m)
    {
        int n = m.GetLength(0);
        int[,] mat = new int[n, n];
        int[] arr = new int[n * n];
        int k = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arr[k++] = m[i, j];
            }
        }

        arr = arr.OrderByDescending(x => x).ToArray();


        for (int i = 0; i < n; i++)
        {
            mat[i, i] = arr[i];
        }

        int counter = n;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j && mat[i, j] == 0)
                {
                    mat[i, j] = arr[counter];
                    counter++;
                }
            }
        }

        return mat;
    }

    static int FirstNoPositive(int[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            bool hasNoPositive = false;

            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (m[i, j] > 0)
                {
                    hasNoPositive = true;
                    break;
                }
            }
            if (!hasNoPositive)
            {
                return (i+1);
            }
        }
        return -1;
    }

    static void PrintFirstNoPositive(int[,] m)
    {
        int firstLineNoPositive = FirstNoPositive(m);

        if (firstLineNoPositive != -1)
        {
            Console.WriteLine($"Первая строка, не содержащая положительных элементов: {firstLineNoPositive}.");
        }
        else
        {
            Console.WriteLine("Не найдено ни одной строки, не содержащей положительных элементов.");
        }
    }

}
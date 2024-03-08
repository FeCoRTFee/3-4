using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Matrix<T> : BasicArray
{
    T[,] mas;
    public Matrix(int n = 3) : base(n)
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(double) ||typeof(T) == typeof(bool))
        {
            mas = new T[number_of_cells,number_of_cells];
        }
        

    }
    public override void Input()
    {
        Console.WriteLine("Enter rows number");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter columns number");
        int columns = Convert.ToInt32(Console.ReadLine());
        mas = new T[rows, columns];
        Console.WriteLine("Enter elements");
        for(int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                mas[i, j] = (T)(object)(Console.ReadLine());
            }

        }
    }

    public override double Average()
    {
        throw new NotImplementedException();
    }

    public override void Print()
    {
        Console.WriteLine("Matrix:");
        for (int i = 0; i < mas.GetLength(0); i++)
        {
            for (int j = 0; j < mas.GetLength(1); j++)
            {
                Console.Write(mas[i, j] + " ");
            }
            Console.WriteLine();

        }
        Console.WriteLine();
    }

    public override void Random()
    {
        Random rnd = new Random();
        Console.WriteLine("Enter rows number");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter columns number");
        int columns = Convert.ToInt32(Console.ReadLine());
        mas = new T[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                
                if (typeof(T) == typeof(int))
                {
                
                    mas[i,j] = (T)(object)rnd.Next(-100, 100);
                }
                else if (typeof(T) == typeof(string))
                {
                    mas[i,j] = (T)(object)GenerateRandomString(10);
                }
                else if (typeof(T) == typeof(double))
                {
                    mas[i,j] = (T)(object)NextDouble(-100.0, 100.0);
                }
                else if (typeof(T) == typeof(bool))
                {
                    mas[i,j] = (T)(object)rnd.Next(0, 1);
                }
            }

        }
    }
    public double NextDouble( double MinValue, double MaxValue)
    {
        Random random = new Random();
        return random.NextDouble() * (MaxValue - MinValue) + MinValue;
    }


    string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();

        char[] randomString = new char[length];

        for (int i = 0; i < length; i++)
        {
            randomString[i] = chars[random.Next(chars.Length)];
        }

        return new string(randomString);
    }

    public override void Recreate(int n)
    {
        mas = new T[number_of_cells, number_of_cells];
    }
    public void ShowReverse()
    {
        for (int i = 0; i < mas.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
            }
            else
            {
                for (int j = mas.GetLength(1) - 1; j >= 0; j--)
                {
                    Console.Write(mas[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}


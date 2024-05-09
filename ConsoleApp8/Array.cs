using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Array<T>  : BasicArray
{
    
    T[] mas;
    public Array(int n = 3) : base(n)
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(double) ||typeof(T) == typeof(bool))
        {
            mas = new T[number_of_cells];
        }
        

    } 
    public override void Input()
    {
        Console.WriteLine("Enter number of elements ");
        int n = Convert.ToInt32(Console.ReadLine());
        mas = new T[n];
        Console.WriteLine("Enter elements ");
        for (int i = 0; i < mas.Length; i++)
        {
            mas[i] = (T)(object)(Console.ReadLine());

        }                                                  
    }


    public override void Print()
    {
        Console.WriteLine("Array:");
        for (int i = 0; i < mas.Length; i++)
        {
            Console.Write(mas[i] +  " ");
        }
        Console.WriteLine();
    }

    public override void Random()
    {
        Console.WriteLine("Enter number of elements ");
        int n = Convert.ToInt32(Console.ReadLine());
        mas = new T[n];
        Random rnd = new Random();
        for (int i = 0; i < mas.Length; i++)
        {
            if (typeof(T) == typeof(int))
            {
                
                mas[i] = (T)(object)rnd.Next(-100, 100);
            }
            else if (typeof(T) == typeof(string))
            {
                mas[i] = (T)(object)GenerateRandomString(10);
            }
            else if (typeof(T) == typeof(double))
            {
                mas[i] = (T)(object)NextDouble(-100.0, 100.0);
            }
            else if (typeof(T) == typeof(bool))
            {
                mas[i] = (T)(object)rnd.Next(0, 1);
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
        mas = new T[number_of_cells];
    }
    public bool CanAdd(T[] masbuffer, T n)
    {
        for (int i = 0; i < masbuffer.Length; i++)
        {
            if (n.Equals(masbuffer[i]))
            {
                return false;
            }
        }
        return true;
    }
    public int GetUniqueCount()
    {
        int count = 0;
        for (int i = 0; i < mas.Length; i++)
        {
            for (int j = 0; j < mas.Length; j++)
            {
                if (mas[i].Equals(mas[j]) && i < j)
                {
                    count++;

                }
            }
        }
        return mas.Length - count;


    }
    public T[] GetUniqueMas()
    {
        Console.WriteLine("Unique mas");
        int new_len = GetUniqueCount();
        T[] new_mas = new T[new_len];
        int j = 0;
        for (int i = 0; i < mas.Length; i++)
        {
            if (CanAdd(new_mas, mas[i]))
            {
                new_mas[j] = mas[i];
                j++;
            }

        }
        return new_mas;
    }

    public override double Average()
    {
        throw new NotImplementedException();
    }
}


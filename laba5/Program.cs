using System;
using System;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///  задача 1
/// </summary>
class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int columns;
    private Random random;

    public MyMatrix(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        this.matrix = new int[rows, columns];
        this.random = new Random();
        Fill();
    }

    public void Fill()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(-10, 11);
            }
        }
    }

    public void ChangeSize(int newRows, int newColumns)
    {
        int[,] newMatrix = new int[newRows, newColumns];

        for (int i = 0; i < Math.Min(rows, newRows); i++)
        {
            for (int j = 0; j < Math.Min(columns, newColumns); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        matrix = newMatrix;
        rows = newRows;
        columns = newColumns;

        if (rows > newRows || columns > newColumns)
        {
            Fill();
        }
    }

    public void ShowPartialy(int startRow, int endRow, int startColumn, int endColumn)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        ShowPartialy(0, rows - 1, 0, columns - 1);
    }

    public int this[int index1, int index2]
    {
        get
        {
            return matrix[index1, index2];
        }
        set
        {
            matrix[index1, index2] = value;
        }
    }

    private int GenerateRandomNumber()
    {
        // Вводите диапазон случайных чисел при запуске программы
        Console.Write("Введите минимальное значение случайного числа: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Введите максимальное значение случайного числа: ");
        int max = int.Parse(Console.ReadLine());

        Random random = new Random();
        return random.Next(min, max + 1);
    }
}







/// <summary>
/// задача 2
/// </summary>


class MyList<T>
{
    private T[] elements;
    private int count;

    public MyList()
    {
        elements = new T[0];
        count = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index >= 0 && index < count)
                return elements[index];
            else
                throw new IndexOutOfRangeException();
        }
    }

    public int Count
    {
        get { return count; }
    }

    public void Add(T element)
    {
        T[] newArray = new T[count + 1];
        for (int i = 0; i < count; i++)
        {
            newArray[i] = elements[i];
        }
        newArray[count] = element;
        elements = newArray;
        count++;
    }
}





/// <summary>
/// задача 3
/// </summary>





class MyDictionary<TKey, TValue>
{
    private TKey[] keys;
    private TValue[] values;
    private int count;

    public MyDictionary()
    {
        keys = new TKey[0];
        values = new TValue[0];
        count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        TKey[] newKeys = new TKey[count + 1];
        TValue[] newValues = new TValue[count + 1];

        for (int i = 0; i < count; i++)
        {
            newKeys[i] = keys[i];
            newValues[i] = values[i];
        }

        newKeys[count] = key;
        newValues[count] = value;

        keys = newKeys;
        values = newValues;
        count++;
    }

    public TValue this[TKey key]
    {
        get
        {
            int index = Array.IndexOf(keys, key);
            if (index != -1)
                return values[index];
            else
                throw new KeyNotFoundException();
        }
    }

    public int Count
    {
        get { return count; }
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }
    }
}




















class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine($"//////////// Задача 1 ////////////");
        Console.WriteLine();
        
        int rows = 3;
        int columns = 4;
        
        MyMatrix matrix = new MyMatrix(rows, columns);
        matrix.Show();
        
        Console.WriteLine();
        
        matrix.ChangeSize(5, 6);
        matrix.Show();
        
        Console.WriteLine();
        
        matrix.ShowPartialy(1, 3, 2, 4);
        
        Console.WriteLine();
        
        matrix[0, 0] = 100;
        int value = matrix[0, 0];
        Console.WriteLine(value);
        
        
        
        
        
        Console.WriteLine();
        Console.WriteLine($"//////////// Задача 2 ////////////");
        Console.WriteLine();
        
        MyList<int> myList = new MyList<int>();

        myList.Add(10);
        myList.Add(20);
        myList.Add(30);

        Console.WriteLine(myList[0]);  // Выводит: 10
        Console.WriteLine(myList[1]);  // Выводит: 20
        Console.WriteLine(myList[2]);  // Выводит: 30

        Console.WriteLine(myList.Count);  // Выводит: 3
        
        
        
        Console.WriteLine();
        Console.WriteLine($"//////////// Задача 3 ////////////");
        Console.WriteLine();
        
        
        MyDictionary<string, int> myDictionary = new MyDictionary<string, int>();

        myDictionary.Add("key1", 10);
        myDictionary.Add("key2", 20);
        myDictionary.Add("key3", 30);

        Console.WriteLine(myDictionary["key1"]);  // Выводит: 10
        Console.WriteLine(myDictionary["key2"]);  // Выводит: 20
        Console.WriteLine(myDictionary["key3"]);  // Выводит: 30

        Console.WriteLine(myDictionary.Count);  // Выводит: 3

        foreach (KeyValuePair<string, int> kvp in myDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
// Выводит:
// Key: key1, Value: 10
// Key: key2, Value: 20
// Key: key3, Value: 30

    }
}


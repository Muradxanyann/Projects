public class MyDictionary<T, U> : IEnumerable<KeyValuePair<T, U>>
{
    public int Count { get; private set;} = 0;
    public int Capacity { get; private set;}

    private T[] keys;

    private U[] values;

    public MyDictionary(int capacity = 4)
    {
        Capacity = capacity;
        keys = new T[capacity];
        values = new U[capacity];
    }

    public bool ContainsKey(T key)
    {
        for (int i = 0; i < Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(keys[i], key))
            return true;
        }
        return false;
    }

    public int IndexOfKey(T key)
    {
        for (int i = 0; i < Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(keys[i], key))
                return i;
        }
        return -1;
    }
    public void Add(T key, U value)
    {
        if (Count == Capacity)
            Resize();
        if (ContainsKey(key))
            throw new ArgumentException($"Key {key} is already exsist");
        keys[Count] = key;
        values[Count++] = value;
    }

    public void Remove(T key)
    {
        int index = IndexOfKey(key);
        if (index == (-1))
            throw new ArgumentException("The key doesnt exsist");
        for (int i = index; i < Count - 1; i++)
        {
            keys[i] = keys[i + 1];
            values[i] = values[i + 1];
        }
        keys[Count - 1] = default!;
        values[Count - 1] = default!;
        Count--;
    }
    public void Resize()
        {
            Capacity *= 2;
            T[] newArr = new T[Capacity];
            U[] usArr = new U[Capacity];
            Array.Copy(keys, newArr, Count);
            Array.Copy(values, usArr, Count);
            keys = newArr;
            values = usArr;
        }

    public void Clear()
    {
        for (int i = 0; i < Count; i++)
        {
            keys[i] = default!;
            values[i] = default!;
        }
        Count = 0;
    }

    public void ShowDictionary()
    {
        for (int i = 0; i < Count; i++)
            System.Console.WriteLine($"{keys[i]} : {values[i]}");
    }

    public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return new KeyValuePair<T, U>(keys[i], values[i]);
        }
    }


    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyDictionary<string, int> dictionary = new MyDictionary<string, int>
        {
            {"some key", 100 },
            {"another", 0 }
        };
        dictionary.ShowDictionary();

    }
}
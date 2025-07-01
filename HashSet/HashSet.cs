/* using System.Dynamic;
using System.Net.NetworkInformation;

class ListNode<T>
{
    public T val { get; private set; }
    public ListNode<T> next { get;  set; }

    public ListNode(T val = default(T), ListNode<T> next = null)
    {
        this.next = next;
        this.val = val;
    }
}
public class MyHashSet<T> {
    private ListNode<T>[] _buckets;
    public int Size {get; set;} = 0;
    public int Capacity {get; set;} = 4;
    public float LoadFactor {get; set;} = 0.75f;

    public MyHashSet()
    {
        _buckets = new ListNode<T>[Capacity];
    }
    
    public void Add(T key) 
    {
        if (Contains(key))
            return;
        if ((double)(Size + 1) / _buckets.Length > LoadFactor)
            Rehash();
        int hash = key.GetHashCode();
        int bucketIndex = GetBucketIndex(hash);
        var newNode = new ListNode<T>(key);
        newNode.next = _buckets[bucketIndex]; 
        _buckets[bucketIndex] = newNode;
        Size++;
    }
    
    public void Remove(T key) 
    {
        int hash = key.GetHashCode();
        int bucketIndex = GetBucketIndex(hash);
        var current = _buckets[bucketIndex];
        if (current == null)
            return;

        if (EqualityComparer<T>.Default.Equals(current.val, key))
        {
            _buckets[bucketIndex] = current.next;
            Size--;
            return;
        }
        while(current != null && current.next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.next.val, key))
            {
                current.next = current.next.next;
                Size--;
                return;
            }
                
            current = current.next;
        }
    }
    
    public bool Contains(T key) 
    {
        int hash = key.GetHashCode();
        int bucketIndex = GetBucketIndex(hash);
        var current = _buckets[bucketIndex];
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.val, key))
                return true;
            current = current.next;
        }
        return false;
        
    }
    public void Rehash()
    {
        int newCapacity = (Capacity == 0) ? 1 : Capacity * 2;
        ListNode<T>[] result = new ListNode<T>[newCapacity];

        foreach (var node in _buckets)
        {
            var current = node;
            while (current != null)
            {
                int hash = current.val.GetHashCode();
                int bucketIndex = (hash & 0x7FFFFFFF) % newCapacity;
                var newNode = new ListNode<T>(current.val);
                newNode.next = result[bucketIndex];
                result[bucketIndex] = newNode;

                current = current.next;
            }
        }
        
        _buckets = result;
        Capacity = newCapacity;
    }
    private int GetBucketIndex(int hashCode)
    {
       return (hashCode & 0x7FFFFFFF) % _buckets.Length;
    }
} */
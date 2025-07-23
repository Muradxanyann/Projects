class ListNode<Tkey, TValue>
{
    public Tkey key { get; private set; }
    public TValue val { get;  set; }
    public ListNode<Tkey, TValue> next { get; set; }

    public ListNode( Tkey key = default(Tkey),TValue val = default(TValue), ListNode<Tkey, TValue> next = null)
    {
        this.next = next;
        this.val = val;
        this.key = key;
    }
}

class HashMap<Tkey, TValue>
{
    public ListNode<Tkey, TValue>[] _buckets;
    public int Size { get; private set; } = 0;
    public int Capacity { get; private set; } = 0;

    public float LoadFactor { get; private set; } = 0.75f;

    public HashMap(int cap)
    {
        if (cap < 0) return;
        _buckets = new ListNode<Tkey, TValue>[cap];
    }

    public void Add(Tkey key, TValue value)
    {
        if (Capacity == 0)
            Rehash();
        if ((double)Size + 1 > Capacity * LoadFactor)
            Rehash();
        int hash = key.GetHashCode();
        int bucketIndex = GetBucketIndex(hash);
        if (ContainsKey(key))
        {
            var curr = _buckets[bucketIndex];
            while (curr != null)
            {
                if (EqualityComparer<Tkey>.Default.Equals(curr.key, key))
                {
                    curr.val = value;
                    return;
                }
                curr = curr.next;
            }
        }

        var newNode = new ListNode<Tkey, TValue>(key, value, _buckets[bucketIndex]);
        _buckets[bucketIndex] = newNode;
        Size++;


    }
    public int GetBucketIndex(int hashCode) => (hashCode & 0x7FFFFFFF) % _buckets.Length;


    public void Rehash()
    {
        int newCapacity = (Capacity == 0) ? 1 : Capacity * 2;
        var res = new ListNode<Tkey, TValue>[newCapacity];
        foreach (var node in _buckets)
        {
            var current = node;
            while (current != null)
            {
                int hash = current.key.GetHashCode();
                int index = (hash & 0x7FFFFFFF) % newCapacity;
                var newNode = new ListNode<Tkey, TValue>(current.key, current.val);
                newNode.next = res[index];
                res[index] = newNode;
                current = current.next;
            }
        }
        _buckets = res;
        Capacity = newCapacity;
    }
    public void Remove(Tkey key)
    {
        if (!ContainsKey(key) || Size == 0)
            return;
        int hash = key.GetHashCode();
        int index = GetBucketIndex(hash);
        var curr = _buckets[index];
        if (EqualityComparer<Tkey>.Default.Equals(curr.key, key))
        {
            _buckets[index] = curr.next;
            Size--;
            return;
        }

        while (curr != null && curr.next != null)
        {
            if (EqualityComparer<Tkey>.Default.Equals(curr.next.key, key))
            {
                curr.next = curr.next.next;
                Size--;
                return;
            }
            curr = curr.next;
        }
    }
    public bool ContainsKey(Tkey key)
    {
        int hash = key.GetHashCode();
        int bucketIndex = GetBucketIndex(hash);
        if (_buckets[bucketIndex] == null)
            return false;
        var curr = _buckets[bucketIndex];
        while (curr != null)
        {
            if (EqualityComparer<Tkey>.Default.Equals(curr.key, key))
                return true;
            curr = curr.next;
        }
        return false;
    }
}
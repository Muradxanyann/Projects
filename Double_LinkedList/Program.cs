namespace DoubleLinkedList
{
    class Node<T>
{
    public T value { get; set; }
    public Node<T>? Next { get; set; }
    public Node<T>? Prev { get; set; }

    public Node(T value = default) : this(value, null, null) { }
    public Node(T value, Node<T>? next, Node<T>? prev)
    {
        this.value = value;
        this.Next = next;
        this.Prev = prev;
    }

}
class DoubleLinkedList<T>
{
    public Node<T>? node { get; set; }

    public DoubleLinkedList(Node<T>? node)
    {
        this.node = node;
    }

    public void PushBack(T value)
    {
        Node<T>? newNode = new Node<T>(value);
        if (node.Next == null)
        {
            node.Next = newNode;
            newNode.Prev = node;
            return;
        }
        var current = this.node.Next;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
        newNode.Prev = current;
    }
    public void PushFront(T value)
    {
        Node<T>? newNode = new(value);
        newNode.Next = this.node.Next;
        if (this.node.Next != null)
        {
            this.node.Next.Prev = newNode;
        }
        newNode.Prev = this.node;
        node.Next = newNode;
    }

    public void PopBack()
    {
        if (node.Next is null)
        {
            Console.WriteLine("The list is empty, nothing to remove");
            return;
        }
        var current = node.Next;
        var prev = node;
        while (current.Next is not null)
        {
            prev = current;
            current = current.Next;
        }
        prev.Next = null;
    }
    public void PopFront()
    {
        if (node.Next is null)
        {
            Console.WriteLine("The list is empty, nothing to remove");
            return;
        }
        if (node.Next.Next is not null)
        {
            node.Next.Next.Prev = node;
            node.Next = node.Next.Next;
            return;
        }
        node.Next = null;
    }
    public void PrintList()
    {
        if (node.Next == null)
        {
            Console.WriteLine("List: [empty]");
            return;
        }
        var current = node.Next;
        Console.Write("List: ");
        while (current != null)
        {
            Console.Write($"{current.value} <-> ");
            current = current.Next;
        }
        Console.WriteLine("X");
    }
    public int GetListCount()
    {
        int count = 0;
        if (node.Next is null)
            return 0;
        var current = node.Next;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public void Insert(int index, T value)
    {
        if (index < 0 || index > GetListCount() + 1)
            return;
        if (index == GetListCount() + 1)
        {
            PushBack(value);
            return;
        }
        if (index == 0)
        {
            PushFront(value);
            return;
        }
        var newNode = new Node<T>(value);
        var current = this.node;
        while (index > 0)
        {
            current = current.Next;
            index--;
        }
        newNode.Next = current.Next;
        if (current.Next != null)
            current.Next.Prev = newNode;
        current.Next = newNode;
        newNode.Prev = current;
    }

    public void Erese(int index)
    {
        if (index < 0 || index >= GetListCount())
            return;
        var current = this.node.Next;
        while (current != null && index > 0)
        {
            current = current.Next;
            index--;
        }
        if (current is not null)
        {
            current.Prev.Next = current.Next;
            if (current.Next is not null)
            {
                current.Next.Prev = current.Prev;
            }
        }

    }
    public bool HasCycle()
    {
        var slow = node;
        var fast = node;
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (fast == slow)
                return true;
        }
        return false;
    }

    public Node<T> GetMidElement()
    {
        var slow = node;
        var fast = node;
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        return slow;
    }
}
static class Program
{
    static void Main(string[] args)
    {
        var node = new Node<int>();
        var list = new DoubleLinkedList<int>(node);
        list.PushFront(10);
        list.PushBack(20);
        list.PushBack(30);
        list.PushBack(50);
        list.PushBack(60);
        list.Insert(5, 70);
        list.Insert(3, 40);
        list.Erese(2);
        list.PrintList();
        //Console.WriteLine(list.HasCycle());
        
        
        

    }
} 
}

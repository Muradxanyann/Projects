using System.Transactions;

class Node<T> where T : IComparable<T>
{
    public T value { get; set; }
    public Node<T> next { get; set; }
    public Node(T value = default(T)!, Node<T> node = null!)
    {
        this.value = value;
        this.next = node;
    }
}
class MyLinkedList<T> where T : IComparable<T>
{
    public Node<T> node { get; set; }
    public MyLinkedList()
    {
        node = new Node<T>();
    }

    public void PushBack(T value)
    {
        var newNode = new Node<T>(value);
        var current = node;
        while (current.next != null)
        {
            current = current.next;
        }
        current.next = newNode;
        newNode.next = null!;
    }

    public void PushFront(T value)
    {
        var newNode = new Node<T>(value);
        newNode.next = node.next;
        node.next = newNode;
    }

    public void PopBack()
    {
        if (node.next == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        var current = node.next;
        var prev = node;
        while (current.next != null)
        {
            prev = current;
            current = current.next;
        }
        prev.next = null!;
    }

    public void PopFront()
    {
        if (node.next == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        var current = node.next;
        node.next = current.next;
        current.next = null!;
    }

    public void Pop(T value)
    {
        if (node.next == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        var current = node.next;
        var prev = node;
        while (current != null)
        {
            if (current.value.Equals(value))
            {
                prev.next = current.next;
                Console.WriteLine($"Removed: {value}");
                return;
            }
            prev = current;
            current = current.next;

        }
        Console.WriteLine($"Value {value} not found in the list.");
    }


    public void PrintList()
    {
        var current = node.next;
        while (current != null)
        {
            Console.Write(current.value + " -> ");

            current = current.next;
        }
        Console.WriteLine("X");
    }

    public void Reverse()
    {
        if (node == null || node.next == null)
            return;
        var current = node.next;
        Node<T> prev = null;
        while (current != null)
        {
            var temp = current.next;
            current.next = prev;
            prev = current;
            current = temp;
        }

        node.next = prev;

    }

    public static Node<T> Merge<T>(Node<T> list1, Node<T> list2) where T : IComparable<T>
    {
        Node<T> dummy = new Node<T>();
        Node<T> tail = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.value.CompareTo(list2.value) <= 0)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            else
            {
                tail.next = list2;
                list2 = list2.next;
            }
            tail = tail.next;
        }

        tail.next = (list1 != null) ? list1 : list2;

        return dummy.next;
    }

    private static Node<T> GetMidNode(Node<T> head)
    {
        if (head == null || head.next == null)
            return head;
        Node<T> slow = head;
        Node<T> fast = head.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    public static Node<T> MergeSort(Node<T> list)
    {
        if (list == null || list.next == null)
            return list;
        var midNode = GetMidNode(list);
        var secondHalf = midNode.next;
        midNode.next = null;
        Node<T> left = MergeSort(list);
        Node<T> right = MergeSort(secondHalf);
        return Merge(left, right);
    }
}


static class Program
{
    static void Main(string[] args)
    {
        MyLinkedList<int> list = new();
        list.PushBack(1);
        list.PushBack(9);
        list.PushBack(8);
        list.PushBack(7);
        list.PushBack(10);
        list.PushBack(9);
        list.PushBack(8);
        var newStart = MyLinkedList<int>.MergeSort(list.node);

        var temp = newStart.next;
        while (temp != null)
        {
            Console.Write(temp.value + " -> ");
            temp = temp.next;
        }
        Console.WriteLine("X");

    }
}

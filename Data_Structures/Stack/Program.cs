public class SimpleStack<T>
{
    private T[] items;
    private int top;
    private int capacity;

    public SimpleStack(int capacity)
    {
        this.capacity = capacity;
        items = new T[capacity];
        top = -1;
    }

    public void Push(T item)
    {
        if (top == capacity - 1)
        {
            throw new InvalidOperationException("Stack is full");
        }

        items[++top] = item;
    }

    public T Pop()
    {
        if (top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return items[top--];
    }

    public T Peek()
    {
        if (top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return items[top];


    }
    public int Count => top + 1;

    public bool IsEmpty => top == -1;
    public bool IsFull => top == capacity - 1;
}
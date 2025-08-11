public class SimpleQueue<T>
{
    private T[] items;
    private int front;
    private int rear;
    private int count;
    private int capacity;

    public SimpleQueue(int capacity)
    {
        this.capacity = capacity;
        items = new T[capacity];
        front = 0;
        rear = -1;
        count = 0;
    }

    public void Enqueue(T item)
    {
        if (count == capacity)
        {
            throw new InvalidOperationException("Queue is full");
        }

        rear = (rear + 1) % capacity;
        items[rear] = item;
        count++;
    }

    public T Dequeue()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = items[front];
        front = (front + 1) % capacity;
        count--;
        return item;
    }

    public T Peek()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return items[front];
    }

    public int Count => count;

    public bool IsEmpty => count == 0;
    public bool IsFull => count == capacity;
}

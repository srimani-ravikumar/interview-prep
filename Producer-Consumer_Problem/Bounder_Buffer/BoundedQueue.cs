public class BoundedQueue<T>
{
    private readonly Queue<T> queue = new Queue<T>();
    private readonly int capacity;

    public BoundedQueue(int capacity)
    {
        this.capacity = capacity;
    }

    public void Enqueue(T item)
    {
        lock (queue)
        {
            while (queue.Count >= capacity)
                Monitor.Wait(queue);

            queue.Enqueue(item);
            Monitor.PulseAll(queue);
        }
    }

    public T Dequeue()
    {
        lock (queue)
        {
            while (queue.Count == 0)
                Monitor.Wait(queue);

            T item = queue.Dequeue();
            Monitor.PulseAll(queue);
            return item;
        }
    }
}


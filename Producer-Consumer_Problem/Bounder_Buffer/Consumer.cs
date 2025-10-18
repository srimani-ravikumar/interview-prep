public class Consumer
{
    private readonly BoundedQueue<string> logQueue;

    public Consumer(BoundedQueue<string> queue)
    {
        logQueue = queue;
    }

    public void Start()
    {
        new Thread(() =>
        {
            while (true)
            {
                string log = logQueue.Dequeue();
                Console.WriteLine($"[Consumer] Writing: {log}");
                Thread.Sleep(200);
            }
        }).Start();
    }
}
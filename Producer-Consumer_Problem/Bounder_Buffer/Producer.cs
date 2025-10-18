public class Producer
{
    private readonly BoundedQueue<string> logQueue;
    private readonly string serviceName;
    private readonly Random random = new Random();

    public Producer(BoundedQueue<string> queue, string service)
    {
        logQueue = queue;
        serviceName = service;
    }

    public void Start()
    {
        new Thread(() =>
        {
            for (int i = 0; i < 20; i++)
            {
                string log = $"[{serviceName}] Log-{i} at {DateTime.Now:HH:mm:ss}";
                logQueue.Enqueue(log);
                Console.WriteLine($"[Producer:{serviceName}] Produced: {log}");
                Thread.Sleep(random.Next(100, 500));
            }
        }).Start();
    }
}
class Driver
{
    static void Main(string[] args)
    {
        var logQueue = new BoundedQueue<string>(10);
        var consumer = new Consumer(logQueue);
        consumer.Start();

        var producers = new List<Producer>
        {
            new Producer(logQueue, "AuthService"),
            new Producer(logQueue, "OrderService"),
            new Producer(logQueue, "PaymentService")
        };

        producers.ForEach(p => p.Start());
    }
}
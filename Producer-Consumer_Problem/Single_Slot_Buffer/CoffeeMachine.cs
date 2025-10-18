namespace ProducerConsumer
{
    // Shared resource: CoffeeMachine acts as a buffer of size 1
    public class CoffeeMachine
    {
        private bool isCoffeeReady = false; // true → coffee ready, false → cup empty
        private readonly object lockObject = new object(); // Monitor lock object

        // Method to be run by the producer thread
        public void MakeCoffee()
        {
            lock (lockObject)
            {
                // If coffee is already ready, producer must wait (buffer is full)
                while (isCoffeeReady)
                {
                    Monitor.Wait(lockObject);
                }

                // Simulate coffee preparation
                Console.WriteLine("☕ Brewing coffee...");
                Thread.Sleep(1000); // Simulate time to make coffee

                // Coffee is now ready
                isCoffeeReady = true;
                Console.WriteLine("✅ Coffee ready!");

                // Notify consumer thread that coffee is available
                Monitor.Pulse(lockObject);
            }
        }

        // Method to be run by the consumer thread
        public void DrinkCoffee()
        {
            lock (lockObject)
            {
                // If no coffee is available, consumer must wait (buffer is empty)
                while (!isCoffeeReady)
                {
                    Monitor.Wait(lockObject);
                }

                // Simulate coffee consumption
                Console.WriteLine("😋 Drinking coffee...");
                Thread.Sleep(1000); // Simulate time to drink coffee

                // Coffee has been consumed
                isCoffeeReady = false;
                Console.WriteLine("🌀 Cup emptied — brew next!");

                // Notify producer that it can brew again
                Monitor.Pulse(lockObject);
            }
        }
    }

    // Driver class
    public class ProducerConsumerProblem
    {
        public static void Main(string[] args)
        {
            CoffeeMachine machine = new CoffeeMachine();

            // Producer thread continuously making coffee
            Thread producer = new Thread(() =>
            {
                while (true)
                {
                    machine.MakeCoffee();
                }
            });

            // Consumer thread continuously drinking coffee
            Thread consumer = new Thread(() =>
            {
                while (true)
                {
                    machine.DrinkCoffee();
                }
            });

            // Start both threads
            producer.Start();
            consumer.Start();

            // Keep the main thread alive
            producer.Join();
            consumer.Join();
        }
    }
}
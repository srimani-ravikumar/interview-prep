// Demonstrates IDisposable pattern
// Focus: deterministic resource cleanup
// using ensures deterministic cleanup.

namespace Basics.ResourceManagement
{
    public class FileHandler : IDisposable
    {
        private bool isDisposed = false;

        public void UseResource()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(nameof(FileHandler));
            }

            Console.WriteLine("Using resource...");
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                Console.WriteLine("Releasing resources...");
                isDisposed = true;
            }
        }
    }

    public class IDisposableBasics
    {
        public static int Main()
        {
            using (FileHandler handler = new FileHandler())
            {
                handler.UseResource();
            } // Dispose called automatically here

            return 0;
        }
    }
}
// Demonstrates Dependency Inversion Principle (DIP)
// Focus: high-level modules depend on abstractions
// Depend on abstractions, not concretions
// Swap Email → SMS → WhatsApp without changing Notification.

namespace Basics.SOLID
{
    // Abstraction
    public interface IMessageService
    {
        void Send(string message);
    }

    // Low-level implementation
    public class EmailService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    // High-level module
    public class Notification
    {
        private readonly IMessageService _messageService;

        public Notification(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify(string message)
        {
            _messageService.Send(message);
        }
    }

    public class SOLIDDependencyInversionDemo
    {
        public static int Main()
        {
            IMessageService service = new EmailService();
            Notification notification = new Notification(service);

            notification.Notify("Hello SOLID");

            return 0;
        }
    }
}
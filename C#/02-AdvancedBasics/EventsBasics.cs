// Demonstrates events
// Focus: publisher-subscriber pattern
// Events encapsulate delegate invocation and prevent misuse.

namespace Basics.Events
{
    // Publisher
    public class Alarm
    {
        // Event based on Action delegate
        public event Action OnAlarmTriggered;

        public void Trigger()
        {
            Console.WriteLine("Alarm triggered!");
            OnAlarmTriggered?.Invoke(); // Safe invocation
        }
    }

    public class EventsBasics
    {
        public static int Main()
        {
            Alarm alarm = new Alarm();

            // Subscriber
            alarm.OnAlarmTriggered += () =>
            {
                Console.WriteLine("Handling alarm event...");
            };

            alarm.Trigger();

            return 0;
        }
    }
}
using System;

namespace class5h
{
    public class Publisher
    {
        public delegate void MyDelegate(string output);// Declare delegate.
        public event MyDelegate BeginOutput;   // Declare event.

        public void Display(string output)
        {
            NotifySubscriber();
            Console.WriteLine(output);                 // Show output.
        }
        private void NotifySubscriber()
        {
            if (BeginOutput != null)
            {
                BeginOutput("Starting output event."); // Raise event.
            }
        }
    }
    public class Program
    {
        // Declare a callback method to receive event notifications.
        public static void OnBeginOutput(string output)
        {
            Console.WriteLine("Inside callback: " + output);
        }
        public static void Main()
        {
            Publisher publisher = new Publisher();

            // Subscribe to event and reference OnBeginOutput() callback.
            publisher.BeginOutput += OnBeginOutput;

            publisher.Display("Hello!  I am a subscriber.");

            // De-reference OnBeginOutput() callback method.
            publisher.BeginOutput -= OnBeginOutput;

            // Output text when not subscribed to the event.
            publisher.Display("Hello!  I am not a subscriber.");
            Console.ReadLine();
        }
    }

}

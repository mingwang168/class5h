using System;

namespace class5h
{
    public class Publisher
    {
        public delegate void MyDelegate(string output);// Declare delegate.
        public event MyDelegate BeginOutput;   // Declare event.
        public event MyDelegate EndOutput;   // Declare event.
        public void Display(string output)
        {
            if (BeginOutput != null)
            {
                BeginOutput("Starting output event."); // Raise event.
            }
            Console.WriteLine(output);
            if (EndOutput != null)
            {
                EndOutput("Ending output event."); // Raise event.
            }// Show output.
        }

    }
    public class Program
    {
        // Declare a callback method to receive event notifications.
        public static void OnBeginOutput(string output)
        {
            Console.WriteLine("Inside begin callback: " + output);
        }
        public static void OnEndOutput(string output)
        {
            Console.WriteLine("Inside end callback: " + output);
        }
        public static void Main()
        {
            Publisher publisher = new Publisher();

            // Subscribe to event and reference OnBeginOutput() callback.
            publisher.BeginOutput += OnBeginOutput;
            publisher.EndOutput += OnEndOutput;

            publisher.Display("Hello!  I am a subscriber to both events.");

            // De-reference OnBeginOutput() callback method.
            publisher.BeginOutput -= OnBeginOutput;

            // Output text when not subscribed to the event.
            publisher.Display("Hello!  I am a subscriber only to the end event.");
            Console.ReadLine();
        }
    }

}

using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nChoose an option: ");

            string choice_RP = Console.ReadLine();

            Activity activity_RP = null;

            if (choice_RP == "1") activity_RP = new BreathingActivity();
            else if (choice_RP == "2") activity_RP = new ReflectionActivity();
            else if (choice_RP == "3") activity_RP = new ListingActivity();
            else if (choice_RP == "4") break;
            else continue;

            activity_RP.RunActivity_RP();
        }
    }
}



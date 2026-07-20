using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    public override void RunActivity_RP()
    {
        DisplayStartMessage_RP();
        int duration_RP = int.Parse(Console.ReadLine());
        SetDuration_RP(duration_RP);

        Console.Clear();
        DateTime end_RP = DateTime.Now.AddSeconds(duration_RP);

        while (DateTime.Now < end_RP)
        {
            Console.WriteLine("Breathe in...");
            Spinner_RP(3);

            Console.WriteLine("Breathe out...");
            Spinner_RP(3);

            Console.WriteLine();
        }

        DisplayEndMessage_RP();
    }
}

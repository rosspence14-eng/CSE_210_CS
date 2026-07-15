using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts_RP = new List<string>()
    {
        "List as many things as you can that make you happy.",
        "List people who have helped you.",
        "List things you are grateful for."
    };

    private Random _rng_RP = new Random();

    public ListingActivity()
        : base("Listing", "This activity helps you focus on positive things by listing them.")
    {
    }

    public override void RunActivity_RP()
    {
        DisplayStartMessage_RP();
        int duration_RP = int.Parse(Console.ReadLine());
        SetDuration_RP(duration_RP);

        Console.Clear();

        string prompt_RP = _prompts_RP[_rng_RP.Next(_prompts_RP.Count)];
        Console.WriteLine(prompt_RP);
        Console.WriteLine("Start listing items. Press Enter after each one.\n");

        DateTime end_RP = DateTime.Now.AddSeconds(duration_RP);
        int count_RP = 0;

        while (DateTime.Now < end_RP)
        {
            Console.Write("> ");
            Console.ReadLine();
            count_RP++;
        }

        Console.WriteLine($"\nYou listed {count_RP} items!");
        DisplayEndMessage_RP();
    }
}

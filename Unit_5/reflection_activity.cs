using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts_RP = new List<string>()
    {
        "Think of a time you helped someone.",
        "Recall a moment you felt proud of yourself.",
        "Think of a time you overcame a challenge."
    };

    private List<string> _questions_RP = new List<string>()
    {
        "Why was this experience meaningful?",
        "What did you learn from it?",
        "How can you apply this lesson today?",
        "What made this moment stand out?"
    };

    private Random _rng_RP = new Random();

    public ReflectionActivity()
        : base("Reflection", "This activity helps you reflect on meaningful moments.")
    {
    }

    public override void RunActivity_RP()
    {
        DisplayStartMessage_RP();
        int duration_RP = int.Parse(Console.ReadLine());
        SetDuration_RP(duration_RP);

        Console.Clear();

        string prompt_RP = _prompts_RP[_rng_RP.Next(_prompts_RP.Count)];
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {prompt_RP} ---\n");
        Console.WriteLine("Press Enter when you're ready...");
        Console.ReadLine();

        DateTime end_RP = DateTime.Now.AddSeconds(duration_RP);

        while (DateTime.Now < end_RP)
        {
            string question_RP = _questions_RP[_rng_RP.Next(_questions_RP.Count)];
            Console.WriteLine(question_RP);
            Spinner_RP(5);
            Console.WriteLine();
        }

        DisplayEndMessage_RP();
    }
}

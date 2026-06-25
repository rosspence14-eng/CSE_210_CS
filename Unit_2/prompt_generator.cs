using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts_RP = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today?",
        "What surprised me today?"
    };

    private Random _rng_RP = new Random();

    public string GetRandomPrompt()
    {
        int index_RP = _rng_RP.Next(_prompts_RP.Count);
        return _prompts_RP[index_RP];
    }
}


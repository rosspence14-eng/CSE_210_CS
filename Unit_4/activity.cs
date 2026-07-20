using System;
using System.Threading;

public abstract class Activity
{
    private string _name_RP;
    private string _description_RP;
    private int _duration_RP;

    public Activity(string name_RP, string description_RP)
    {
        _name_RP = name_RP;
        _description_RP = description_RP;
    }

    public void SetDuration_RP(int duration_RP)
    {
        _duration_RP = duration_RP;
    }

    public int GetDuration_RP()
    {
        return _duration_RP;
    }

    public void DisplayStartMessage_RP()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name_RP} Activity.\n");
        Console.WriteLine(_description_RP);
        Console.WriteLine("\nHow many seconds would you like this activity to last?");
        Console.Write("> ");
    }

    public void DisplayEndMessage_RP()
    {
        Console.WriteLine("\nGreat job!");
        Console.WriteLine($"You completed {_duration_RP} seconds of the {_name_RP} Activity.");
        Thread.Sleep(2000);
    }

    protected void Spinner_RP(int seconds_RP)
    {
        string[] frames_RP = { "|", "/", "-", "\\" };
        DateTime end_RP = DateTime.Now.AddSeconds(seconds_RP);

        int index_RP = 0;
        while (DateTime.Now < end_RP)
        {
            Console.Write(frames_RP[index_RP]);
            Thread.Sleep(200);
            Console.Write("\b");
            index_RP = (index_RP + 1) % frames_RP.Length;
        }
    }

    public abstract void RunActivity_RP();
}

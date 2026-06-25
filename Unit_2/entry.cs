using System;

public class Entry
{
    private string _date_RP;
    private string _prompt_RP;
    private string _response_RP;

    public Entry(string date, string prompt, string response)
    {
        _date_RP = date;
        _prompt_RP = prompt;
        _response_RP = response;
    }

    // Getters for CSV saving
    public string GetDate() => _date_RP;
    public string GetPrompt() => _prompt_RP;
    public string GetResponse() => _response_RP;

    public void Display()
    {
        Console.WriteLine($"[ {_date_RP} ] {_prompt_RP}");
        Console.WriteLine(_response_RP);
        Console.WriteLine();
    }
}


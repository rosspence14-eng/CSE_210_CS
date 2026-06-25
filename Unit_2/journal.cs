using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entriesList_RP = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entriesList_RP.Add(entry);
    }

    public void DisplayAll()
    {
        if (entriesList_RP.Count == 0)
        {
            Console.WriteLine("No entries in the journal yet.\n");
            return;
        }

        foreach (Entry entry in entriesList_RP)
        {
            entry.Display();
        }
    }

    public void SaveToCsv(string filename_RP)
    {
        using (StreamWriter writer_RP = new StreamWriter(filename_RP))
        {
            foreach (Entry entry in entriesList_RP)
            {
                string date_RP = EscapeCsv(entry.GetDate());
                string prompt_RP = EscapeCsv(entry.GetPrompt());
                string response_RP = EscapeCsv(entry.GetResponse());

                writer_RP.WriteLine($"{date_RP},{prompt_RP},{response_RP}");
            }
        }

        Console.WriteLine("Journal saved as CSV.\n");
    }

    public void LoadFromCsv(string filename_RP)
    {
        if (!File.Exists(filename_RP))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        entriesList_RP.Clear();

        string[] lines_RP = File.ReadAllLines(filename_RP);
        foreach (string line in lines_RP)
        {
            string[] parts_RP = ParseCsvLine(line);

            if (parts_RP.Length == 3)
            {
                entriesList_RP.Add(new Entry(parts_RP[0], parts_RP[1], parts_RP[2]));
            }
        }

        Console.WriteLine("CSV journal loaded.\n");
    }

    private string EscapeCsv(string field_RP)
    {
        if (field_RP.Contains(",") || field_RP.Contains("\""))
        {
            field_RP = field_RP.Replace("\"", "\"\"");
            return $"\"{field_RP}\"";
        }
        return field_RP;
    }

    private string[] ParseCsvLine(string line_RP)
    {
        List<string> fields_RP = new List<string>();
        bool inQuotes = false;
        string current_RP = "";

        for (int i = 0; i < line_RP.Length; i++)
        {
            char c = line_RP[i];

            if (c == '"')
            {
                if (inQuotes && i + 1 < line_RP.Length && line_RP[i + 1] == '"')
                {
                    current_RP += '"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                fields_RP.Add(current_RP);
                current_RP = "";
            }
            else
            {
                current_RP += c;
            }
        }

        fields_RP.Add(current_RP);
        return fields_RP.ToArray();
    }
}


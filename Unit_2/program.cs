using System;

class Program
{
    static void Main()
    {
        Journal journal_RP = new Journal();
        PromptGenerator generator_RP = new PromptGenerator();

        bool running_RP = true;

        while (running_RP)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal as CSV");
            Console.WriteLine("4. Load journal from CSV");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice_RP = Console.ReadLine();
            Console.WriteLine();

            if (choice_RP == "1")
            {
                string prompt_RP = generator_RP.GetRandomPrompt();
                Console.WriteLine(prompt_RP);
                Console.Write("> ");
                string response_RP = Console.ReadLine();

                string date_RP = DateTime.Now.ToShortDateString();
                Entry entry_RP = new Entry(date_RP, prompt_RP, response_RP);
                journal_RP.AddEntry(entry_RP);

                Console.WriteLine("Entry recorded.\n");
            }
            else if (choice_RP == "2")
            {
                journal_RP.DisplayAll();
            }
            else if (choice_RP == "3")
            {
                Console.Write("Enter filename to save (example: journal.csv): ");
                string filename_RP = Console.ReadLine();
                journal_RP.SaveToCsv(filename_RP);
            }
            else if (choice_RP == "4")
            {
                Console.Write("Enter filename to load (example: journal.csv): ");
                string filename_RP = Console.ReadLine();
                journal_RP.LoadFromCsv(filename_RP);
            }
            else if (choice_RP == "5")
            {
                running_RP = false;
            }
            else
            {
                Console.WriteLine("Invalid choice.\n");
            }
        }
    }
}


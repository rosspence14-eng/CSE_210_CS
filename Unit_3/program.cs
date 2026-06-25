using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<ScriptureReference> references_RP = new List<ScriptureReference>()
        {
            new ScriptureReference("John", 1, 1),
            new ScriptureReference("John", 3, 16),
            new ScriptureReference("Matthew", 5, 14),
            new ScriptureReference("Philippians", 4, 13),
            new ScriptureReference("1 John", 4, 8)
        };

        // ive been learning greek thought this would be fun \_'-'_/
        List<string> texts_RP = new List<string>()
        {
            "Ἐν ἀρχῇ ἦν ὁ Λόγος",
            "Οὕτως γὰρ ἠγάπησεν ὁ Θεὸς τὸν κόσμον",
            "Ὑμεῖς ἐστε τὸ φῶς τοῦ κόσμου",
            "Πάντα ἰσχύω ἐν τῷ ἐνδυναμοῦντί με",
            "Ὁ Θεὸς ἀγάπη ἐστίν"
        };

        Random rng_RP = new Random();
        int index_RP = rng_RP.Next(references_RP.Count);

        ScriptureReference reference_RP = references_RP[index_RP];
        string text_RP = texts_RP[index_RP];

        Scripture scripture_RP = new Scripture(reference_RP, text_RP);

        Console.Clear();
        Console.WriteLine(scripture_RP.GetDisplayText());
        Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");

        while (true)
        {
            Console.Write("\n> ");
            string input_RP = Console.ReadLine();

            if (input_RP == "quit")
            {
                break;
            }

            scripture_RP.HideRandomWords(2);

            Console.Clear();
            Console.WriteLine(scripture_RP.GetDisplayText());

            if (scripture_RP.IsFullyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program complete.");
                break;
            }
        }
    }
}

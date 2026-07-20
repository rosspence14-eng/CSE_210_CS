using System;
using System.Collections.Generic;
using System.IO;

//
// Exceeding requirements:
// - Added a simple leveling system: every 1000 points_RP = +1 level_RP.
// - Display level_RP on main menu and after recording events.
//

public abstract class Goal
{
    private string _name_RP;
    private string _description_RP;
    private int _points_RP;
    private bool _isComplete_RP;

    public Goal(string name_RP, string description_RP, int points_RP)
    {
        _name_RP = name_RP;
        _description_RP = description_RP;
        _points_RP = points_RP;
        _isComplete_RP = false;
    }

    public string GetName_RP()
    {
        return _name_RP;
    }

    public string GetDescription_RP()
    {
        return _description_RP;
    }

    public int GetPoints_RP()
    {
        return _points_RP;
    }

    public bool IsComplete_RP()
    {
        return _isComplete_RP;
    }

    protected void SetComplete_RP(bool value_RP)
    {
        _isComplete_RP = value_RP;
    }

    public abstract int RecordEvent_RP();
    public abstract string GetStatusString_RP();
    public abstract string GetStringRepresentation_RP();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name_RP, string description_RP, int points_RP)
        : base(name_RP, description_RP, points_RP)
    {
    }

    public override int RecordEvent_RP()
    {
        if (!IsComplete_RP())
        {
            SetComplete_RP(true);
            return GetPoints_RP();
        }
        return 0;
    }

    public override string GetStatusString_RP()
    {
        string box_RP = IsComplete_RP() ? "[X]" : "[ ]";
        return $"{box_RP} {GetName_RP()} ({GetDescription_RP()})";
    }

    public override string GetStringRepresentation_RP()
    {
        return $"SimpleGoal|{GetName_RP()}|{GetDescription_RP()}|{GetPoints_RP()}|{IsComplete_RP()}";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name_RP, string description_RP, int points_RP)
        : base(name_RP, description_RP, points_RP)
    {
    }

    public override int RecordEvent_RP()
    {
        // Never complete, always award points
        return GetPoints_RP();
    }

    public override string GetStatusString_RP()
    {
        return $"[∞] {GetName_RP()} ({GetDescription_RP()})";
    }

    public override string GetStringRepresentation_RP()
    {
        return $"EternalGoal|{GetName_RP()}|{GetDescription_RP()}|{GetPoints_RP()}";
    }
}

public class ChecklistGoal : Goal
{
    private int _targetCount_RP;
    private int _currentCount_RP;
    private int _bonusPoints_RP;

    public ChecklistGoal(string name_RP, string description_RP, int points_RP,
                         int targetCount_RP, int bonusPoints_RP)
        : base(name_RP, description_RP, points_RP)
    {
        _targetCount_RP = targetCount_RP;
        _bonusPoints_RP = bonusPoints_RP;
        _currentCount_RP = 0;
    }

    public int GetCurrentCount_RP()
    {
        return _currentCount_RP;
    }

    public int GetTargetCount_RP()
    {
        return _targetCount_RP;
    }

    public int GetBonusPoints_RP()
    {
        return _bonusPoints_RP;
    }

    public void SetCurrentCount_RP(int value_RP)
    {
        _currentCount_RP = value_RP;
    }

    public override int RecordEvent_RP()
    {
        int totalPoints_RP = GetPoints_RP();
        _currentCount_RP++;

        if (_currentCount_RP >= _targetCount_RP && !IsComplete_RP())
        {
            SetComplete_RP(true);
            totalPoints_RP += _bonusPoints_RP;
        }

        return totalPoints_RP;
    }

    public override string GetStatusString_RP()
    {
        string box_RP = IsComplete_RP() ? "[X]" : "[ ]";
        return $"{box_RP} {GetName_RP()} ({GetDescription_RP()}) -- Completed {_currentCount_RP}/{_targetCount_RP}";
    }

    public override string GetStringRepresentation_RP()
    {
        return $"ChecklistGoal|{GetName_RP()}|{GetDescription_RP()}|{GetPoints_RP()}|{_targetCount_RP}|{_bonusPoints_RP}|{_currentCount_RP}|{IsComplete_RP()}";
    }
}

public class GoalManager
{
    private List<Goal> _goals_RP = new List<Goal>();
    private int _score_RP = 0;

    public void AddGoal_RP(Goal goal_RP)
    {
        _goals_RP.Add(goal_RP);
    }

    public void ListGoals_RP()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i_RP = 0; i_RP < _goals_RP.Count; i_RP++)
        {
            Console.WriteLine($"{i_RP + 1}. {_goals_RP[i_RP].GetStatusString_RP()}");
        }
    }

    public void DisplayScore_RP()
    {
        int level_RP = _score_RP / 1000;
        Console.WriteLine($"\nCurrent Score: {_score_RP} points_RP (Level {level_RP})");
    }

    public void RecordEvent_RP()
    {
        if (_goals_RP.Count == 0)
        {
            Console.WriteLine("\nNo goals_RP to record yet.");
            return;
        }

        ListGoals_RP();
        Console.Write("\nWhich goal did you accomplish? Enter number: ");
        string input_RP = Console.ReadLine();
        int index_RP;

        if (int.TryParse(input_RP, out index_RP))
        {
            index_RP--;
            if (index_RP >= 0 && index_RP < _goals_RP.Count)
            {
                int pointsEarned_RP = _goals_RP[index_RP].RecordEvent_RP();
                _score_RP += pointsEarned_RP;
                Console.WriteLine($"\nYou earned {pointsEarned_RP} points_RP!");
                DisplayScore_RP();
            }
            else
            {
                Console.WriteLine("\nInvalid goal_RP selection.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid input_RP.");
        }
    }

    public void SaveGoals_RP(string filename_RP)
    {
        using (StreamWriter writer_RP = new StreamWriter(filename_RP))
        {
            writer_RP.WriteLine(_score_RP);
            foreach (Goal goal_RP in _goals_RP)
            {
                writer_RP.WriteLine(goal_RP.GetStringRepresentation_RP());
            }
        }
        Console.WriteLine("\nGoals_RP saved.");
    }

    public void LoadGoals_RP(string filename_RP)
    {
        if (!File.Exists(filename_RP))
        {
            Console.WriteLine("\nFile not found.");
            return;
        }

        _goals_RP.Clear();

        string[] lines_RP = File.ReadAllLines(filename_RP);
        if (lines_RP.Length == 0) return;

        _score_RP = int.Parse(lines_RP[0]);

        for (int i_RP = 1; i_RP < lines_RP.Length; i_RP++)
        {
            string line_RP = lines_RP[i_RP];
            string[] parts_RP = line_RP.Split('|');

            string type_RP = parts_RP[0];

            if (type_RP == "SimpleGoal")
            {
                string name_RP = parts_RP[1];
                string desc_RP = parts_RP[2];
                int points_RP = int.Parse(parts_RP[3]);
                bool complete_RP = bool.Parse(parts_RP[4]);

                SimpleGoal goal_RP = new SimpleGoal(name_RP, desc_RP, points_RP);
                if (complete_RP)
                {
                    goal_RP.RecordEvent_RP(); // mark complete without extra points
                }
                _goals_RP.Add(goal_RP);
            }
            else if (type_RP == "EternalGoal")
            {
                string name_RP = parts_RP[1];
                string desc_RP = parts_RP[2];
                int points_RP = int.Parse(parts_RP[3]);

                EternalGoal goal_RP = new EternalGoal(name_RP, desc_RP, points_RP);
                _goals_RP.Add(goal_RP);
            }
            else if (type_RP == "ChecklistGoal")
            {
                string name_RP = parts_RP[1];
                string desc_RP = parts_RP[2];
                int points_RP = int.Parse(parts_RP[3]);
                int target_RP = int.Parse(parts_RP[4]);
                int bonus_RP = int.Parse(parts_RP[5]);
                int current_RP = int.Parse(parts_RP[6]);
                bool complete_RP = bool.Parse(parts_RP[7]);

                ChecklistGoal goal_RP = new ChecklistGoal(name_RP, desc_RP, points_RP, target_RP, bonus_RP);
                goal_RP.SetCurrentCount_RP(current_RP);
                if (complete_RP)
                {
                    // mark complete without extra points
                    goal_RP.RecordEvent_RP();
                }
                _goals_RP.Add(goal_RP);
            }
        }

        Console.WriteLine("\nGoals_RP loaded.");
    }

    public void CreateGoal_RP()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a type: ");
        string choice_RP = Console.ReadLine();

        Console.Write("Enter goal name_RP: ");
        string name_RP = Console.ReadLine();

        Console.Write("Enter goal description_RP: ");
        string desc_RP = Console.ReadLine();

        Console.Write("Enter points_RP for this goal: ");
        int points_RP = int.Parse(Console.ReadLine());

        if (choice_RP == "1")
        {
            SimpleGoal goal_RP = new SimpleGoal(name_RP, desc_RP, points_RP);
            AddGoal_RP(goal_RP);
        }
        else if (choice_RP == "2")
        {
            EternalGoal goal_RP = new EternalGoal(name_RP, desc_RP, points_RP);
            AddGoal_RP(goal_RP);
        }
        else if (choice_RP == "3")
        {
            Console.Write("Enter target count_RP (how many times to complete): ");
            int target_RP = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus points_RP when completed: ");
            int bonus_RP = int.Parse(Console.ReadLine());

            ChecklistGoal goal_RP = new ChecklistGoal(name_RP, desc_RP, points_RP, target_RP, bonus_RP);
            AddGoal_RP(goal_RP);
        }
        else
        {
            Console.WriteLine("\nInvalid goal type_RP.");
        }
    }
}

class Program
{
    static void Main()
    {
        GoalManager manager_RP = new GoalManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            manager_RP.DisplayScore_RP();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("\nChoose an option: ");

            string choice_RP = Console.ReadLine();

            if (choice_RP == "1")
            {
                manager_RP.CreateGoal_RP();
            }
            else if (choice_RP == "2")
            {
                manager_RP.ListGoals_RP();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (choice_RP == "3")
            {
                manager_RP.RecordEvent_RP();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (choice_RP == "4")
            {
                Console.Write("\nEnter filename_RP to save: ");
                string filename_RP = Console.ReadLine();
                manager_RP.SaveGoals_RP(filename_RP);
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (choice_RP == "5")
            {
                Console.Write("\nEnter filename_RP to load: ");
                string filename_RP = Console.ReadLine();
                manager_RP.LoadGoals_RP(filename_RP);
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (choice_RP == "6")
            {
                break;
            }
        }
    }
}

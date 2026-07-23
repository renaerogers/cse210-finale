using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore() => _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordGoalEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal targetGoal = _goals[index];
        
        if (targetGoal.IsComplete())
        {
            Console.WriteLine("This goal is already completed!");
            return;
        }

        int pointsEarned = targetGoal.RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // First line stores the score
            outputFile.WriteLine(_score);

            // Write each goal representation
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear(); // Clear existing goals
        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0) return;

        // Line 1 contains score
        _score = int.Parse(lines[0]);

        // Remaining lines are goal records
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string goalType = parts[0];
            string[] details = parts[1].Split(',');

            if (goalType == "SimpleGoal")
            {
                string name = details[0];
                string desc = details[1];
                int points = int.Parse(details[2]);
                bool isComplete = bool.Parse(details[3]);
                _goals.Add(new SimpleGoal(name, desc, points, isComplete));
            }
            else if (goalType == "EternalGoal")
            {
                string name = details[0];
                string desc = details[1];
                int points = int.Parse(details[2]);
                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = details[0];
                string desc = details[1];
                int points = int.Parse(details[2]);
                int bonus = int.Parse(details[3]);
                int target = int.Parse(details[4]);
                int amountCompleted = int.Parse(details[5]);
                _goals.Add(new ChecklistGoal(name, desc, points, bonus, target, amountCompleted));
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }

    public int GetLevel()
    {
        // Level 1 starts at 0 pts, Level 2 at 1000 pts, Level 3 at 2000 pts, etc.
        return (_score / 1000) + 1;
    }

    public string GetProgressToNextLevel()
    {
        int currentLevelPoints = _score % 1000;
        return $"{currentLevelPoints}/1000 pts to Level {GetLevel() + 1}";
    }
}
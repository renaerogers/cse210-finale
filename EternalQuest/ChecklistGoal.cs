using System; 

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor for NEW goals
    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Constructor overload for LOADING from file
    public ChecklistGoal(string name, string description, int points, int bonus, int target, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            return _points + _bonus; // Base points + bonus reward!
        }
        return _points;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string statusSymbol = IsComplete() ? "[X]" : "[ ]";
        return $"{statusSymbol} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}
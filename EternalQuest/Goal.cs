using System; 

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _shortName;

    // Must be overridden in derived classes to handle point logic
    public abstract int RecordEvent();

    // Must be overridden to evaluate completion status
    public abstract bool IsComplete();

    // Formats display string for console lists: [ ] Name (Description)
    public virtual string GetDetailsString()
    {
        string statusSymbol = IsComplete() ? "[X]" : "[ ]";
        return $"{statusSymbol} {_shortName} ({_description})";
    }

    // Formats goal details into a single line string for file storage
    public abstract string GetStringRepresentation();
}
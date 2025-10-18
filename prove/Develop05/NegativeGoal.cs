public class NegativeGoal : Goal
{
    private int _timesRecorded;

    public NegativeGoal(string name, string description, int pointsLost) : base(name, description, pointsLost)
    {
        _timesRecorded = 0;
    }

    public NegativeGoal(string name, string description, int pointsLost, int timesRecorded) 
        : base(name, description, pointsLost)
    {
        _timesRecorded = timesRecorded;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        Console.WriteLine($"\n⚠️ Oops! You recorded: {_name}");
        Console.WriteLine($"You lost {_points} points. Don't give up!");
        Console.WriteLine($"Times recorded: {_timesRecorded}");
        return -_points; // Negative points
    }

    public override bool IsComplete()
    {
        return false; // Never complete, just tracking
    }

    public override string GetDetailsString()
    {
        return $"[!] {_name} ({_description}) -- Times recorded: {_timesRecorded}";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name}|{_description}|{_points}|{_timesRecorded}";
    }
}
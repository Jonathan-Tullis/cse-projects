public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        int pointsEarned = _points;

        if (_amountCompleted >= _target)
        {
            Console.WriteLine($"\n🏆 AMAZING! You completed the checklist goal: {_name}!");
            Console.WriteLine($"You earned {_points} points plus a bonus of {_bonus} points!");
            pointsEarned += _bonus;
        }
        else
        {
            Console.WriteLine($"\n⭐ Progress on: {_name}!");
            Console.WriteLine($"You earned {_points} points!");
            Console.WriteLine($"Completed {_amountCompleted}/{_target} times");
        }

        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }
}
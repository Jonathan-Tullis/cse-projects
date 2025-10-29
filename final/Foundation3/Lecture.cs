public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + 
            $"\nType: Lecture" +
            $"\nSpeaker: {_speaker}" +
            $"\nCapacity: {_capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Lecture\n" + base.GetShortDescription();
    }

    public string GetSpeaker()
    {
        return _speaker;
    }

    public int GetCapacity()
    {
        return _capacity;
    }
}
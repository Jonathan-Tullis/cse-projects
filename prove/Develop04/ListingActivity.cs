public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _itemCount;
    private List<string> _usedPrompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _itemCount = 0;
        _usedPrompts = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        PauseWithCountdown(5);
        Console.WriteLine();

        List<string> items = GetListFromUser();
        _itemCount = items.Count;

        Console.WriteLine($"You listed {_itemCount} items!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        // Smart selection - no repeats until all used
        if (_usedPrompts.Count >= _prompts.Count)
        {
            _usedPrompts.Clear();
        }

        Random random = new Random();
        string prompt;
        
        do
        {
            prompt = _prompts[random.Next(_prompts.Count)];
        } while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);
        return prompt;
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        return items;
    }
}
public class GratitudeActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;

    public GratitudeActivity()
    {
        _name = "Gratitude Activity";
        _description = "This activity will help you cultivate gratitude by reflecting on the blessings in your life. Recognizing what you're grateful for can increase happiness and reduce stress.";
        
        _prompts = new List<string>
        {
            "What are three things that made you smile today?",
            "Who is someone you're grateful to have in your life and why?",
            "What is a challenge you've faced that you're now grateful for?",
            "What is something about your health or body you're thankful for?",
            "What is a simple pleasure you enjoyed recently?"
        };

        _usedPrompts = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine();
        Console.WriteLine("Reflect deeply on the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("Take your time to think about your answer...");
        Console.Write("You may begin in: ");
        PauseWithCountdown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        Console.WriteLine("Write your thoughts (press Enter after each one):");
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
        }

        Console.WriteLine();
        Console.WriteLine("Thank you for taking time to practice gratitude!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
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
}
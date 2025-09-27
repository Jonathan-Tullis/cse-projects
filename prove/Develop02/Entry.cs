using System;
using System.Collections.Generic;

public class Entry
{
    public string _prompt;
    public string _time;
    public string _location;
    public string _entry;

    public void GivePrompt()
    {
        List<string> prompts = new List<string>()
        {
            "What moment today made me feel most proud?",
            "What conversation had the biggest impact on me today?",
            "What would I tell my younger self about today?",
            "What small victory should I celebrate from today?",
            "What surprised me most about today?",
            "How did I show courage today, even in a small way?",
            "What pattern in my thinking did I notice today?",
            "What made me feel most connected to others today?",
            "What would I change about how I spent my time today?",
            "What moment today do I want to remember in five years?"
        };
        
        Random rand = new Random();
        int randomIndex = rand.Next(prompts.Count);
        _prompt = prompts[randomIndex];
        Console.WriteLine(_prompt);
    }

    public void CollectEntry()
    {
        Console.Write("> ");
        _entry = Console.ReadLine();
    }

    public void GetTime()
    {
        DateTime currentTime = DateTime.Now;
        _time = currentTime.ToShortDateString();
    }

    public void GetLocation()
    {
        Console.Write("Where are you today? ");
        _location = Console.ReadLine();
    }
}
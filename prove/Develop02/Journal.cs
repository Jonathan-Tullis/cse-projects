using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{

    public Journal()
    {
    }
    public List<Entry> _entries = new List<Entry>();
    public string _filename;



    public void Save()
    {
        Console.WriteLine("What is the name of the file?");
        _filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._time}|{entry._location}|{entry._prompt}|{entry._entry}");
            }
        }
        Console.WriteLine($"Journal saved to {_filename}");

    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry._time}");
            Console.WriteLine($"Location: {entry._location}");
            Console.WriteLine($"Prompt: {entry._prompt}");
            Console.WriteLine($"Entry: {entry._entry}");
            Console.WriteLine();
        }
    }

    public void Load()
    {
        Console.WriteLine("What is the name of the file?");
        _filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(_filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                Entry entry = new Entry();
                entry._time = parts[0];
                entry._location = parts[1];
                entry._prompt = parts[2];
                entry._entry = parts[3];
                _entries.Add(entry);
            }
        }
    }

}
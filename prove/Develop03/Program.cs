using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<MemoryVerse> scriptureLibrary = CreateScriptureLibrary();
        
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine();
        
        MemoryVerse selectedVerse = SelectScripture(scriptureLibrary);
        
        Console.WriteLine();
        Console.WriteLine("Press Enter to begin memorizing...");
        Console.ReadLine();
        
        bool keepGoing = true;
        
        while (keepGoing)
        {
            Console.Clear();
            Console.WriteLine(selectedVerse.GetDisplayText());
            Console.WriteLine();
            
            if (selectedVerse.AllWordsConcealed())
            {
                Console.WriteLine("Congratulations! You have hidden all the words!");
                Console.WriteLine("Keep practicing to memorize this scripture!");
                keepGoing = false;
            }
            else
            {
                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
                string userInput = Console.ReadLine();
                
                if (userInput.ToLower() == "quit")
                {
                    keepGoing = false;
                    Console.WriteLine("Thanks for practicing! Keep up the good work!");
                }
                else
                {
                    selectedVerse.ConcealRandomWords(3);
                }
            }
        }
    }
    
    static List<MemoryVerse> CreateScriptureLibrary()
    {
        List<MemoryVerse> library = new List<MemoryVerse>();
        
        VerseLocation location1 = new VerseLocation("Jeremiah", 17, 7);
        MemoryVerse verse1 = new MemoryVerse(location1, "Blessed is the man that trusteth in the Lord and whose hope the Lord is");
        library.Add(verse1);
        
        VerseLocation location2 = new VerseLocation("John", 14, 27);
        MemoryVerse verse2 = new MemoryVerse(location2, "Peace I leave with you my peace I give unto you not as the world giveth give I unto you Let not your heart be troubled neither let it be afraid");
        library.Add(verse2);
        
        VerseLocation location3 = new VerseLocation("1 Corinthians", 13, 13);
        MemoryVerse verse3 = new MemoryVerse(location3, "And now abideth faith hope charity these three but the greatest of these is charity");
        library.Add(verse3);
        
        VerseLocation location4 = new VerseLocation("Moroni", 10, 20);
        MemoryVerse verse4 = new MemoryVerse(location4, "Wherefore there must be faith and if there must be faith there must also be hope and if there must be hope there must also be charity");
        library.Add(verse4);

        VerseLocation location5 = new VerseLocation("Hebrews", 11, 1);
        MemoryVerse verse5 = new MemoryVerse(location5, "Now faith is the substance of things hoped for the evidence of things not seen");
        library.Add(verse5);
        
        return library;
    }
    
    static MemoryVerse SelectScripture(List<MemoryVerse> library)
    {
        Console.WriteLine("Select a scripture to memorize:");
        Console.WriteLine();
        
        for (int i = 0; i < library.Count; i++)
        {
            int displayNumber = i + 1;
            Console.WriteLine($"{displayNumber}. {library[i].GetDisplayText()}");
            Console.WriteLine();
        }
        
        Console.Write("Enter your choice (1-4): ");
        string input = Console.ReadLine();
        int choice = int.Parse(input);
        
        int index = choice - 1;
        
        if (index >= 0 && index < library.Count)
        {
            return library[index];
        }
        else
        {
            Console.WriteLine("Invalid choice. Selecting first scripture.");
            return library[0];
        }
    }
}
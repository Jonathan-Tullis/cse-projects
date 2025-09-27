public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool useingJournal = true;


        Console.WriteLine("Welcome to your journal!");

        while (useingJournal)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");

            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {

                case 1:
                    Entry newEntry = new Entry();
                    newEntry.GetTime();        // Get current date first
                    newEntry.GivePrompt();     // Show random prompt
                    newEntry.CollectEntry();   // Get user's response
                    newEntry.GetLocation();    // Get location
                    journal._entries.Add(newEntry);
                    break;

                case 2:
                    journal.Display();
                    break;

                case 3:
                    journal.Load();
                    break;

                case 4:
                    journal.Save();
                    break;
                case 5:
                    useingJournal = false;
                    Console.WriteLine("You are done using the journal!");
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;

            }
            Console.WriteLine();

        }

    }
}
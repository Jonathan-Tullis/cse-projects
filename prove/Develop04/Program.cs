using System;

class Program
{
    private static int _breathingCount = 0;
    private static int _reflectingCount = 0;
    private static int _listingCount = 0;
    private static int _gratitudeCount = 0;
    private static int _totalTimeSpent = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflecting Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Gratitude Activity (BONUS)");
            Console.WriteLine("  5. View Activity Log");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                _breathingCount++;
                _totalTimeSpent += breathing.GetDuration();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                _reflectingCount++;
                _totalTimeSpent += reflecting.GetDuration();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                _listingCount++;
                _totalTimeSpent += listing.GetDuration();
            }
            else if (choice == "4")
            {
                GratitudeActivity gratitude = new GratitudeActivity();
                gratitude.Run();
                _gratitudeCount++;
                _totalTimeSpent += gratitude.GetDuration();
            }
            else if (choice == "5")
            {
                DisplayActivityLog();
            }
            else if (choice == "6")
            {
                DisplayFinalStats();
                break;
            }
        }
    }

    private static void DisplayActivityLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log for This Session:");
        Console.WriteLine("==============================");
        Console.WriteLine($"Breathing Activities: {_breathingCount}");
        Console.WriteLine($"Reflecting Activities: {_reflectingCount}");
        Console.WriteLine($"Listing Activities: {_listingCount}");
        Console.WriteLine($"Gratitude Activities: {_gratitudeCount}");
        Console.WriteLine($"Total Time Spent: {_totalTimeSpent} seconds");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void DisplayFinalStats()
    {
        Console.Clear();
        int totalActivities = _breathingCount + _reflectingCount + _listingCount + _gratitudeCount;
        Console.WriteLine("Thank you for using the Mindfulness Program!");
        Console.WriteLine($"You completed {totalActivities} activities today.");
        Console.WriteLine($"Total mindfulness time: {_totalTimeSpent} seconds ({_totalTimeSpent / 60} minutes)");
        Console.WriteLine("Keep up the great work!");
    }
}
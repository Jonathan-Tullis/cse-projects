using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Conference Center Drive", "Salt Lake City", "UT", "USA");
        Address address2 = new Address("456 Garden Street", "Portland", "OR", "USA");
        Address address3 = new Address("789 Park Avenue", "Seattle", "WA", "USA");

        Lecture lecture = new Lecture(
            "The Future of Artificial Intelligence",
            "Join us for an enlightening discussion on the latest developments in AI technology and its impact on society.",
            "November 15, 2024",
            "7:00 PM",
            address1,
            "Dr. Sarah Mitchell",
            100
        );

        Reception reception = new Reception(
            "Annual Charity Gala",
            "Help us raise funds for local education initiatives at our elegant evening reception.",
            "December 5, 2024",
            "6:30 PM",
            address2,
            "rsvp@charitygala.org"
        );

        OutdoorGathering outdoorGathering = new OutdoorGathering(
            "Summer Community Picnic",
            "Bring your family and friends for a day of fun, food, and games in the park!",
            "July 20, 2024",
            "12:00 PM",
            address3,
            "Sunny with temperatures in the mid-70s"
        );

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        Console.WriteLine("EVENT MARKETING MESSAGES");
        Console.WriteLine("========================\n");

        foreach (Event ev in events)
        {
            Console.WriteLine("STANDARD DETAILS:");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("FULL DETAILS:");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("SHORT DESCRIPTION:");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Maria", 420);
        video1.AddComment(new Comment("John Smith", "Great recipe! Made it last night and it was delicious."));
        video1.AddComment(new Comment("Sarah Johnson", "Thanks for the clear instructions!"));
        video1.AddComment(new Comment("Mike Brown", "What temperature should the water be?"));
        video1.AddComment(new Comment("Emily Davis", "Love your cooking videos!"));
        videos.Add(video1);

        Video video2 = new Video("Introduction to Programming", "TechGuru", 900);
        video2.AddComment(new Comment("Alex Chen", "This helped me so much with my homework!"));
        video2.AddComment(new Comment("Jessica Lee", "Very clear explanation of the concepts."));
        video2.AddComment(new Comment("David Park", "Can you do a video on loops next?"));
        videos.Add(video2);

        Video video3 = new Video("Yoga for Beginners", "WellnessWithSam", 1200);
        video3.AddComment(new Comment("Linda Martinez", "Perfect for starting my day!"));
        video3.AddComment(new Comment("Robert Wilson", "These stretches really helped my back pain."));
        video3.AddComment(new Comment("Amanda Taylor", "How often should I do this routine?"));
        video3.AddComment(new Comment("Chris Anderson", "Subscribed! Looking forward to more videos."));
        videos.Add(video3);

        Video video4 = new Video("Travel Vlog: Paris", "AdventureSeeker", 1800);
        video4.AddComment(new Comment("Sophie Laurent", "Paris is beautiful! Great shots."));
        video4.AddComment(new Comment("Pierre Dubois", "You should visit the Latin Quarter next time!"));
        video4.AddComment(new Comment("Maria Garcia", "Adding this to my travel bucket list."));
        videos.Add(video4);

        Console.WriteLine("YouTube Video Tracker");
        Console.WriteLine("=====================\n");

        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine(); 
        }
    }
}
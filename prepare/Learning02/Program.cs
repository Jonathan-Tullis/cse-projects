using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Idaho National Laboratory";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2020;
        job1._endYear = 2024;



        Job job2 = new Job();
        job2._company = "Google";
        job2._jobTitle = "Machine Learning Engineer";
        job2._startYear = 2024;
        job2._endYear = 2025;

        Resume resume = new Resume();
        resume._personsName = "Jonathan Tullis";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.DisplayJobDetails();
    }
}
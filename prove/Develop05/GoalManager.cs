public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private List<string> _badges;
    private int _goalsCompleted;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _badges = new List<string>();
        _goalsCompleted = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. View Badges & Stats");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DisplayStats();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("\nThanks for using Eternal Quest! Keep up the great work!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine($"Player: Quest Hero");
        Console.WriteLine($"Level: {_level} | Score: {_score} points");
        
        int nextLevelPoints = GetPointsForNextLevel();
        int pointsToNext = nextLevelPoints - _score;
        Console.WriteLine($"Points to next level: {pointsToNext}");
        Console.WriteLine("========================================");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("Your Goals:");
        Console.WriteLine("========================================");
        
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet! Create one to get started.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (Bad Habit)");
        Console.Write("Which type of goal would you like to create? ");
        
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (type)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            case "4":
                newGoal = new NegativeGoal(name, description, points);
                break;
            default:
                Console.WriteLine("Invalid goal type!");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("\n✅ Goal created successfully!");
        
        // Check for first goal badge
        if (_goals.Count == 1 && !_badges.Contains("Goal Setter"))
        {
            _badges.Add("Goal Setter");
            Console.WriteLine("🏅 New Badge Earned: Goal Setter!");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            int pointsEarned = _goals[choice].RecordEvent();
            int previousScore = _score;
            _score += pointsEarned;
            
            // Prevent negative scores
            if (_score < 0)
            {
                _score = 0;
            }

            // Check if goal is complete
            if (_goals[choice].IsComplete())
            {
                _goalsCompleted++;
                CheckBadges();
            }

            // Check for level up
            CheckLevelUp(previousScore);
        }
        else
        {
            Console.WriteLine("Invalid goal number!");
        }
    }

    private void CheckLevelUp(int previousScore)
    {
        int previousLevel = CalculateLevel(previousScore);
        int currentLevel = CalculateLevel(_score);

        if (currentLevel > previousLevel)
        {
            _level = currentLevel;
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║        🎊 LEVEL UP! 🎊            ║");
            Console.WriteLine($"║     You are now Level {_level}!         ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            CheckBadges();
        }
    }

    private int CalculateLevel(int score)
    {
        // Each level requires 1000 points more than the previous
        return (score / 1000) + 1;
    }

    private int GetPointsForNextLevel()
    {
        return _level * 1000;
    }

    private void CheckBadges()
    {
        // Check for various badges
        if (_goalsCompleted >= 5 && !_badges.Contains("Dedicated"))
        {
            _badges.Add("Dedicated");
            Console.WriteLine("🏅 New Badge Earned: Dedicated (Complete 5 goals)!");
        }

        if (_level >= 5 && !_badges.Contains("Unstoppable"))
        {
            _badges.Add("Unstoppable");
            Console.WriteLine("🏅 New Badge Earned: Unstoppable (Reach Level 5)!");
        }

        if (_level >= 10 && !_badges.Contains("Legend"))
        {
            _badges.Add("Legend");
            Console.WriteLine("🏅 New Badge Earned: Legend (Reach Level 10)!");
        }

        if (_goalsCompleted >= 20 && !_badges.Contains("Master"))
        {
            _badges.Add("Master");
            Console.WriteLine("🏅 New Badge Earned: Master (Complete 20 goals)!");
        }
    }

    private void DisplayStats()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("📊 YOUR STATISTICS");
        Console.WriteLine("========================================");
        Console.WriteLine($"Current Level: {_level}");
        Console.WriteLine($"Total Score: {_score} points");
        Console.WriteLine($"Goals Created: {_goals.Count}");
        Console.WriteLine($"Goals Completed: {_goalsCompleted}");
        Console.WriteLine($"\n🏅 Badges Earned ({_badges.Count}):");
        
        if (_badges.Count == 0)
        {
            Console.WriteLine("  No badges yet. Keep working on your goals!");
        }
        else
        {
            foreach (string badge in _badges)
            {
                Console.WriteLine($"  ⭐ {badge}");
            }
        }
        Console.WriteLine("========================================");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Save score, level, and goals completed
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);
            outputFile.WriteLine(_goalsCompleted);
            
            // Save badges
            outputFile.WriteLine(string.Join(",", _badges));

            // Save each goal
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("\n💾 Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            
            _goals.Clear();
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            _goalsCompleted = int.Parse(lines[2]);
            
            // Load badges
            _badges.Clear();
            if (!string.IsNullOrWhiteSpace(lines[3]))
            {
                _badges.AddRange(lines[3].Split(','));
            }

            // Load goals starting from line 4
            for (int i = 4; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string goalType = parts[0];
                string[] data = parts[1].Split("|");

                Goal goal = null;

                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3]));
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(data[0], data[1], int.Parse(data[2]));
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), 
                                                int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]));
                        break;
                    case "NegativeGoal":
                        goal = new NegativeGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]));
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("\n📂 Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("\nFile not found!");
        }
    }

    public int GetScore()
    {
        return _score;
    }
}
using System;

public class Program
{
    public static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            // Display Level & Score Header -rar
            int level = (manager.GetScore() / 1000) + 1;
            Console.WriteLine($"\nYou have {manager.GetScore()} points | Level {level}");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoalHelper(manager);
                    break;
                case "2":
                    manager.DisplayGoalDetails();
                    break;
                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    break;
                case "5":
                    RecordEventHelper(manager);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    // Helper 1: Handles creating new goals based on user choices
    private static void CreateGoalHelper(GoalManager manager)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (typeChoice == "1")
        {
            manager.AddGoal(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == "2")
        {
            manager.AddGoal(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type selected.");
        }
    }

    // Helper 2: Lists goals and prompts the user to select one to log
    private static void RecordEventHelper(GoalManager manager)
    {
        manager.DisplayGoalDetails();
        Console.Write("\nWhich goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            // Convert 1-based user input to 0-based array index
            manager.RecordGoalEvent(choice - 1);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
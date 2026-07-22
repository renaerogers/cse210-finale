using System;

class Program
{
    private bool _running = true;
    private readonly EquationParser _parser = new EquationParser();

    public bool IsRunning()
    {
        return _running;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("==============================="); // Hehe, fun formatting -rar
        Console.WriteLine("      EQUATION SOLVER MENU     ");
        Console.WriteLine("===============================");
        Console.WriteLine("1. Enter Equation");
        Console.WriteLine("2. Equation Help");
        Console.WriteLine("3. Quit");
        Console.Write("Select an option (1-3): ");
    }

    public string GetEquation()
    {
        Console.Write("\nEnter an equation: ");
        return Console.ReadLine();
    }

    public void DisplayResult(Operation operation)
    {
        // Executes inherited display method -rar
        operation.Display();
    }

    public void DisplayHelp()
    {
        Console.WriteLine("\n------------------------------------------------"); // More fancy dancy formatting -rar
        Console.WriteLine("                 EQUATION HELP                  ");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Supported Operators:");
        Console.WriteLine("  +   Addition          (e.g., 12 + 4)");
        Console.WriteLine("  -   Subtraction       (e.g., 15 - 8)");
        Console.WriteLine("  *   Multiplication    (e.g., 6 * 7)");
        Console.WriteLine("  /   Division          (e.g., 20 / 4)");
        Console.WriteLine("  ^   Exponentiation    (e.g., 2 ^ 3)");
        Console.WriteLine(" -/   Square Root       (e.g., -/ 16)");
        Console.WriteLine("\nRules:");
        Console.WriteLine(" - Variables (e.g., 'x', 'a') will throw an exception.");
        Console.WriteLine(" - Negative numbers and decimal values are supported.");
        Console.WriteLine("------------------------------------------------\n");
    }

    public void Run()
    {
        DisplayMenu();
        string choice = Console.ReadLine()?.Trim();

        switch (choice)
        {
            case "1":
                string input = GetEquation();
                try
                {
                    // Polymorphism with parse returning an abstract Operation instance -rar
                    Operation op = _parser.Parse(input);
                    op.Execute();
                    DisplayResult(op);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERROR]: {ex.Message}\n");
                }
                break;

            case "2":
                DisplayHelp();
                break;

            case "3":
                _running = false;
                Console.WriteLine("\nExiting calculation program. Goodbye!");
                break;

            default:
                Console.WriteLine("\nInvalid option. Please enter 1, 2, or 3.\n");
                break;
        }
    }

    static void Main(string[] args)
    {
        Program program = new Program();

        while (program.IsRunning())
        {
            program.Run();
        }
    }
}